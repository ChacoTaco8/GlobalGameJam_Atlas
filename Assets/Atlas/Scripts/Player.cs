using System;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public Text crewmatesFoundText;
    public Text returnToSpaceShipText;
    
    public int crewmatesFound = 0;
    private int crewmatesTotal = 5;

    private bool allCrewmatesFound = false;
    public bool isMoving = false;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Astronaut"))
        {
            crewmatesFound++;
            crewmatesFoundText.text = (crewmatesTotal - crewmatesFound).ToString();
            if (crewmatesFound >= crewmatesTotal)
            {
                // Separate audio for finding all crewmates? 
                returnToSpaceShipText.enabled = true;
            }
            else
            {
                // PLay default audio
                Debug.Log("Henlo");
            }
            Destroy(other.gameObject);
        }
    }
}
