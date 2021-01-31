using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int crewmatesFound = 0;
    private int crewmatesTotal = 5;

    private bool allCrewmatesFound = false;

    private void Update()
    {
        if (crewmatesFound >= crewmatesTotal) allCrewmatesFound = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Astronaut"))
        {
            crewmatesFound++;
            Destroy(other.gameObject);
        }
    }
}
