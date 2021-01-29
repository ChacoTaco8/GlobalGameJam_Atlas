using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using UnityEngine;

public class AtlasShruggedAndDidTheLocomotion : MonoBehaviour, AxisState.IInputAxisProvider
{
    [SerializeField, Range(0f, 100f)] float maxSpeed = 10f;
    public Vector3 currentGravity;

    [SerializeField, Range(0f, 10f)] float jumpHeight = 10f;

    [SerializeField, Range(0f, 100f)] 
    float maxAcceleration = 10f, maxAirAcceleration = 1f;

    [SerializeField, Range(0f, 90f)] 
    private float _maxGroundAngle = 45f;
    private float _minGroundDotProduct = 45f;
    
    [SerializeField, Range(0f, 90f)] 
    private float _maxStairsAngle = 45f;
    private float _minStairsDotProduct = 45f;
    
    [SerializeField, Range(0f, 100f)]
    float _maxSnapSpeed = 100f;
    
    [SerializeField, Min(0f)]
    float _snapProbeDistance = 1f;
    public LayerMask snapToLayers;
    public LayerMask stairsMask;
    
    [SerializeField]
    [Range(0f,1f)]
    private float _contactNormalVsUpForJumpMix;
    
    public float _jumpGravityCurveButtonHeldT;
    public float jumpGravityCurveButtonHeldTSpeed;
    public AnimationCurve jumpGravityCurve;
    [MinMaxSlider(9.81f, 9.81f * 5.0f)] 
    public Vector2 gravityMinMax;
    

    private Rigidbody _body;
    private Rigidbody _connectedBody;
    private Rigidbody _previousConnectedBody;
    private bool _jumpRequest = false;
    private float _jumpReqTimestamp = 0f;
    private float _trueJumpReqTimestamp = 0f;
    private float _lastGroundedTimestamp = 0f;
    private int _physStepsSinceLastGrounded= 0;
    private int _physStepsSinceLastJump= 0;
    [SerializeField, Range(0.05f, 1.0f)] private float _jumpWindow = 0.1f;

    [SerializeField, Range(0.05f, 1.0f)] private float _groundedWindow = 0.1f;

    public Transform VisualTransform;
    public Animator VisualAnimator;
    
    private Vector3 _contactNormal;
    private Vector3 _steepNormal;
    private int _groundContactCount, _steepContactCount;

    private bool OnSteep => _steepContactCount> 0;
    
    Vector3 lastJumpDirection = Vector3.zero;

    [SerializeField] private Transform _PlayerInputSpace;
    
    public bool _onStrictGround => _groundContactCount > 0;
    public bool OnGround =>  ((Time.unscaledTime - _lastGroundedTimestamp) < _groundedWindow);

    public bool HasFreshJumpRequest =>  ((Time.unscaledTime - _jumpReqTimestamp) < _jumpWindow);
    
    //Only comes from true input not this fake pogostick
    public bool HasTrueFreshJumpRequest =>  ((Time.unscaledTime - _trueJumpReqTimestamp) < _jumpWindow);

    
    private void OnValidate()
    {
        _minGroundDotProduct = Mathf.Cos(Mathf.Deg2Rad * _maxGroundAngle);
        _minStairsDotProduct = Mathf.Cos(Mathf.Deg2Rad * _maxStairsAngle);
        
    }

    private void Awake()
    {
        OnValidate();
    }

    // Start is called before the first frame update
    private int _XCamAxis = 0;
    private int _YCamAxis = 1;
    void Start()
    {

        _body = GetComponent<Rigidbody>();
        
        if (_cinemachine != null)
        {
           _cinemachine.m_XAxis.SetInputAxisProvider(_XCamAxis,this); 
           _cinemachine.m_YAxis.SetInputAxisProvider(_YCamAxis,this); 
        }
    }


    private void OnCollisionEnter(Collision other)
    {
        EvaluateCollision(other);
    }

    private void OnCollisionExit(Collision other)
    {
    }
    private void OnCollisionStay(Collision other)
    {
        EvaluateCollision(other);
    }

    void EvaluateCollision(Collision other)
    {
        float minDot = getMinDot(other.gameObject.layer);
        for (int i = 0; i < other.contactCount; i++)
        {
            Vector3 normal = other.contacts[i].normal;
            if (normal.y >= minDot)
            {
                _groundContactCount++;
                _lastGroundedTimestamp = Time.unscaledTime;
                _contactNormal += normal;
                _connectedBody = other.rigidbody;
            }
            else if (normal.y > -0.01f)
            {
                _steepContactCount++;
                _steepNormal += normal;
                if (_connectedBody == null)
                {
                    _connectedBody = other.rigidbody;
                }
            }
        }

    }

    bool CheckForSteepContacts()
    {
        if (_steepContactCount > 1)
        {
            _steepNormal.Normalize();
            if (_steepNormal.y >= _minGroundDotProduct)
            {
                _groundContactCount++;
                _contactNormal = _steepNormal;
                return true;
            }
        }
        return false;
    }

    Vector3 velocity = new Vector3(0f,0f,0f);

    private Vector3 desiredVelocity,_connectionVelocity,_connectionWorldPosition,_connectionLocalPosition;
    
    

    [SerializeField]
    private CinemachineFreeLook _cinemachine;

    
    public float GetAxisValue(int axis)
    {
        if (axis == _XCamAxis)
        {
            return 0f;
            //return HelInput.Axis(Action.CamHorizontal);
        }
        if (axis == _YCamAxis)
        {
            return 0f;
            //return HelInput.Axis(Action.CamVertical);
        }

        return 0f;

    }
    
    // Update is called once per frame
    void Update()
    {
        
        Vector2 input = new Vector2(0f,1f); //until we get input up and running
       input = Vector2.ClampMagnitude(input,1.0f);

        if (_PlayerInputSpace != null)
        {
            Vector3 fwd = _PlayerInputSpace.forward;
            fwd.y = 0.0f;
            fwd.Normalize();
            Vector3 right = _PlayerInputSpace.right;
            right.y = 0.0f;
            right.Normalize();
            desiredVelocity = (right * input.x + input.y * fwd )*maxSpeed;
        }
        else
        {
            desiredVelocity = new Vector3(input.x, 0f, input.y) * maxSpeed;
        }

        //todo input
        bool jumpButtonHeld = false; //HelInput.ButtonHeld(Action.Jump);
        if (jumpButtonHeld)
        {
            _jumpGravityCurveButtonHeldT += jumpGravityCurveButtonHeldTSpeed * Time.deltaTime;
            float evaluatedGravity = jumpGravityCurve.Evaluate(_jumpGravityCurveButtonHeldT);
            currentGravity = new Vector3(0f,-Mathf.Lerp(gravityMinMax.x,gravityMinMax.y,evaluatedGravity),0f);
        }
        else
        { //max gravity when not held
            _jumpGravityCurveButtonHeldT = 0f;
            currentGravity = new Vector3(0f, -gravityMinMax.y ,0f);
        }


        var jumpButtonPressed = false; 
        if (jumpButtonPressed)
        {
            _jumpReqTimestamp = Time.unscaledTime;
            _trueJumpReqTimestamp= Time.unscaledTime;
            _jumpRequest = true;
        }
        
        Debug.DrawLine(transform.position,transform.position + lastJumpDirection*3.0f,Color.magenta);
           
        
        //todo transfer states to animator / character
        //HelmettaVisualAnimator?.SetBool("InWallSlide",OnSteep && !OnGround); 

    }


    private void FixedUpdate()
    {
        UpdateState();
        AdjustVelocity();
        ClearState();
    }

    private int _airFramesCount = 0;

    void ClearState()
    {
        _contactNormal = _steepNormal = _connectionVelocity = Vector3.zero;
        _groundContactCount =_steepContactCount = 0;
        _previousConnectedBody = _connectedBody;
        _connectedBody = null;
    }
    

    private void UpdateState()
    {
           
        _physStepsSinceLastGrounded += 1;
        if (_connectedBody)
        {

            if (_connectedBody.isKinematic || _connectedBody.mass >= _body.mass)
            {
                UpdateConnectionState();
            }
        }

        if (_physStepsSinceLastGrounded >= 2 && OnGround)
        {
            Land();
        }
        
        velocity = _body.velocity;
        if (OnGround || SnapToGround() || CheckForSteepContacts())
        {
           _contactNormal.Normalize(); 
           _physStepsSinceLastGrounded = 0;
        }
        else
        {
            _contactNormal = Vector3.up;
        }
        if (_jumpRequest)
        {
            //if we request jumps in the air - at some point , that jump command will be too old.
            if ((HasFreshJumpRequest) && Jump())
            {
                _jumpRequest = false;
            }
            else if (!HasFreshJumpRequest && !OnGround)
            {
                _jumpRequest = false;
            }
        }

    }

    void UpdateConnectionState()
    {
        if (_connectedBody == _previousConnectedBody)
        {
            
            Vector3 connectionMovement = _connectedBody.transform.TransformPoint(_connectionLocalPosition) - _connectionWorldPosition;
            _connectionVelocity = connectionMovement / Time.deltaTime; 
        }
        _connectionWorldPosition = _body.position;
        _connectionLocalPosition = _connectedBody.transform.InverseTransformPoint(_connectionWorldPosition);
    }

    private bool SnapToGround()
    {
        if (_physStepsSinceLastGrounded > 1 || HasFreshJumpRequest)
        {
            return false;
        }

        float speed = velocity.magnitude;
        if (speed > _maxSnapSpeed)
        {
            return false;
        }
        
        if (!Physics.Raycast(_body.position, Vector3.down, out RaycastHit hit,_snapProbeDistance,snapToLayers))
        {
            return false;
        }

        //hit.collider.
        if (hit.normal.y < getMinDot(hit.collider.gameObject.layer))
        {
            return false;
        }

        _physStepsSinceLastGrounded = 1;
        _contactNormal = hit.normal;
        _connectedBody = hit.rigidbody;
        float dot = Vector3.Dot(velocity, hit.normal);
        if (dot > 0f)
        {
            velocity = (velocity - hit.normal * dot).normalized * speed;
        }
        return true;
    }

    
    void AdjustVelocity()
    {
        Vector3 xAxis = ProjectOnContactPlane(Vector3.right).normalized;
        Vector3 zAxis = ProjectOnContactPlane(Vector3.forward).normalized;

        Vector3 relativeVelocity = velocity - _connectionVelocity;
        float currentX = Vector3.Dot(relativeVelocity, xAxis);
        float currentZ = Vector3.Dot(relativeVelocity, zAxis);
        
        
        float acceleration = _onStrictGround ? maxAcceleration : maxAirAcceleration;
        float maxSpeedChange = acceleration * Time.deltaTime;

        float newX = Mathf.MoveTowards(currentX, desiredVelocity.x, maxSpeedChange);
        float newZ = Mathf.MoveTowards(currentZ, desiredVelocity.z, maxSpeedChange);

        
        
        velocity += currentGravity*Time.deltaTime;
        velocity += xAxis*(newX - currentX) + zAxis * (newZ - currentZ);
        
        
        float anyMotion = velocity.x + velocity.z;
        if (Mathf.Abs(anyMotion) > 0.1f)
        {
            Vector3 velosDirection = new Vector3(velocity.x,0f,velocity.z).normalized;
            //todo Visual connection 
            //HelmettaVisual?.LookAt(_body.position + velosDirection*3.0f,Vector3.up);
            
        }
        else
        {
            //todo visual connection
            //HelmettaVisual.localRotation = Quaternion.identity;
            //HelmettaVisual?.Rotate(Vector3.forward,pogoAngleInputTilt,Space.Self);
        }


        if (OnSteep && !OnGround)
        {
            //todo visual connection
            //HelmettaVisual?.LookAt(_body.position + _steepNormal*3.0f,Vector3.up);
        }

        float anyDesiredMotion = desiredVelocity.magnitude;
        
        float runSpeedT = Vector3.Magnitude(new Vector3(newX,0f,newZ)) / maxSpeed;

        //todo connect with visuals
        /*
        HelmettaVisualAnimator?.SetFloat("Speed",runSpeedT); 
        HelmettaVisualAnimator?.SetFloat("UpwardsMotion",velocity.y > 0.0f ? 1.0f : 0.0f); 
        */


        Vector3 displacement = velocity * Time.deltaTime;
        _body.velocity = velocity;
    }

    
    bool Jump()
    {
        if (OnGround)
        {
            lastJumpDirection = Vector3.Lerp(_contactNormal,Vector3.up,_contactNormalVsUpForJumpMix);
        }
        else if (OnSteep)
        {
            lastJumpDirection = (_steepNormal + Vector3.up).normalized;
        }
        else
        {
            return false;
        }
        lastJumpDirection = (lastJumpDirection + Vector3.up).normalized;

        


        float jumpH = jumpHeight;
        currentGravity.y = - gravityMinMax.y;
        float jumpSpeed= Mathf.Sqrt(-2f * currentGravity.y * jumpH);

        float priorToClamping = jumpSpeed;
        float alignedSpeed = Vector3.Dot(velocity, lastJumpDirection);
        
        if (alignedSpeed > 0f)
        {
            jumpSpeed = Mathf.Max(jumpSpeed - alignedSpeed, 0f);
        }

        //Because we would like wall jumps that are arcadey - we will remove current gravity from wall-jumps.
        //this is likeley something to tweak later depending on how we want them jumps to feel
        //Remove gravity
        if (OnSteep)
        {
            Vector3 normGrav = currentGravity.normalized;
            float velosGravity = Vector3.Dot(velocity, normGrav);
            velocity -= normGrav* velosGravity;
        }
        
        
        velocity += lastJumpDirection * jumpSpeed;
        _physStepsSinceLastJump = 0;

        //todo animation states
        //HelmettaVisualAnimator?.SetTrigger("Jump"); 
        return true;
    }

    void Land()
    {
        Debug.Log("We think we landed just about now..");
        
        //todo land animationStates etc.. or do what we want to do.
        //HelmettaVisualAnimator?.SetTrigger("Landed"); 
    }

    float getMinDot(int layer)
    {
        return (stairsMask & (1 << layer)) == 0 ? _minGroundDotProduct : _minStairsDotProduct;
    }

    Vector3 ProjectOnContactPlane(Vector3 vector)
    {
        return vector - _contactNormal * Vector3.Dot(vector, _contactNormal);
    }

}
