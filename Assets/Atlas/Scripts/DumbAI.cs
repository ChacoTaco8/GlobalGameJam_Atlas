using System;
using UnityEngine;
using Random = UnityEngine.Random;
using SensorToolkit;

[RequireComponent(typeof(Sensor))]
public class DumbAI : MonoBehaviour
{

    [Header("Movement")] 
    public float moveSpeed = 5f;
    public float chaseSpeed = 15f;
    public float hoverHeight = 10f;
    public float increasedSpeedRatio = 0.2f;

    private Vector3 patrolDirection;
    private Vector3 lastTargetPosition;
    private bool isSearchingForPlayer;
    private bool stillSensingPlayer;
    private bool isAboutToRunIntoWall = false;
    
    private float currentSpeed;
    private float patrolDuration;
    private float lastPatrolDirectionTime;

    [Header("Detection")]
    public float lookingRadius;
    public float chaseRadius;
    public float godVisionTimer = 1.0f;
    private float godVisionStartTime = 0f;

    [Header("State info")]
    [SerializeField] private State state;
    [SerializeField] private GameObject target;

    private Sensor _sensor;
    
    void Start()
    {
        _sensor = GetComponent<Sensor>();
        state = State.patrol;
    }

    void Update()
    {
        LookForPlayer();
    }

    public void IsAboutToRunIntoWall()
    {
        lastPatrolDirectionTime = 0;
    }
    
    private void LookForPlayer()
    {
        if (_sensor.GetNearest() != null && !isSearchingForPlayer)
        {
            target = _sensor.GetNearest();
            float distanceToPlayer = Vector3.Distance(transform.position, target.transform.position);
            if (distanceToPlayer <= chaseRadius)
            {
                state = State.dive;
            } else if (distanceToPlayer <= lookingRadius)
            {
                state = State.alert;
            }
        }
        else if (isSearchingForPlayer)
        {
            if (Vector3.Distance(transform.position, lastTargetPosition) <= 0.04f)
            {
                isSearchingForPlayer = false;
            }
        }
        else if (state != State.patrol)
        {
            target = null;
            state = State.patrol;
        }
    }

    private void FixedUpdate()
    {
        switch (state)
        {
            case State.patrol:
                PatrolState();
                break;
            case State.alert:
                AlertState();
                break;
            case State.dive:
                ChaseState();
                break;
            default:
                state = State.patrol;
                break;
        }
    }

    #region StateLogic

    private void ChaseState()
    {
        transform.LookAt(target.transform);
        if (currentSpeed < chaseSpeed) currentSpeed += increasedSpeedRatio;
        else currentSpeed = chaseSpeed;
        Vector3 moveDirection = (target.transform.position - transform.position).normalized;
        moveDirection = new Vector3(moveDirection.x, moveDirection.y, moveDirection.z);
        transform.position += moveDirection * (currentSpeed * Time.deltaTime);
    }

    private void AlertState()
    {
        isSearchingForPlayer = true;

        // Play audio intense music
        SensePlayer();
        SetSpeedAndRotation();
        Vector3 moveDirection = (lastTargetPosition - transform.position).normalized;
        transform.position += moveDirection * (moveSpeed * Time.deltaTime);
    }

    private void SetSpeedAndRotation()
    {
        transform.LookAt(lastTargetPosition);
        if (currentSpeed < moveSpeed) currentSpeed += increasedSpeedRatio;
        else if (currentSpeed > moveSpeed) currentSpeed -= increasedSpeedRatio;
        else currentSpeed = chaseSpeed;
    }

    private void SensePlayer()
    {
        bool sensingPlayer = _sensor.IsDetected(target);
        
        if (!sensingPlayer && Time.time >= godVisionStartTime + godVisionTimer)
        {
            godVisionStartTime = Time.time;
        }
        
        if (!sensingPlayer && !stillSensingPlayer) lastTargetPosition = new Vector3(lastTargetPosition.x, hoverHeight, lastTargetPosition.z);
        else lastTargetPosition = new Vector3(target.transform.position.x, hoverHeight, target.transform.position.z);
                
    }

    private void PatrolState()
    {
        isSearchingForPlayer = false;
        // Play audio make sure the calm song is played.

        // Get random direction, move for a random duration, go back to idle or repeat.
        if (Time.time >= lastPatrolDirectionTime + patrolDuration)
        {
            lastPatrolDirectionTime = Time.time;
            patrolDuration = Random.Range(3f, 8f);
            float xDir = Random.Range(-1.0f, 1.0f);
            float zDir = Random.Range(-1.0f, 1.0f);
            patrolDirection = new Vector3(xDir, 0, zDir);
        }

        if (patrolDirection != null)
        {
            transform.position += patrolDirection * (moveSpeed * Time.deltaTime);
            transform.rotation = Quaternion.LookRotation(patrolDirection);
        }
        else
        {
            transform.position += Vector3.forward * (moveSpeed * Time.deltaTime);
            transform.rotation = Quaternion.LookRotation(Vector3.forward);
        }
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, 1.4f, 10.8f), transform.position.z);
    }

    #endregion

    private enum State
    {
        patrol,
        alert,
        dive 
    }
}
