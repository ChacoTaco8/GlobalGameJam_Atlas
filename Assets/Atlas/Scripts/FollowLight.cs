using UnityEngine;

public class FollowLight : MonoBehaviour
{
    public GameObject light;
    public float yDistance = 1.18f;

    private void FixedUpdate()
    {
        Vector3 myTrans = transform.position;
        light.transform.position = new Vector3(myTrans.x, myTrans.y + yDistance, myTrans.z);
    }
}
