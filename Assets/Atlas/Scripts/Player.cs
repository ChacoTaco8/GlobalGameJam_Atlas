using UnityEngine;

public class Player : MonoBehaviour
{
    
    private GameManager _manager;

    private void Awake()
    {
        _manager = GameManager.Instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Astronaut"))
        {
            _manager.FoundCrewmate();
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals("Alien"))
        {
            _manager.playerIsDead = true;
        }
    }
}
