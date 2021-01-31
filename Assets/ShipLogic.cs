using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipLogic : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            Debug.Log("Player in vicinity");
            if (GameManager.Instance.allCrewmatesFound)
            {
                GameManager.Instance.hasReturnedToShip = true;
            }
        }
    }
}
