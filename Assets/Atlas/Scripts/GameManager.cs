using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int crewmatesFound = 0;
    public int crewmatesTotal = 5;
    
    public Text crewmatesFoundText;
    public Text returnToSpaceShipText;

    public bool allCrewmatesFound = false;
    public bool hasReturnedToShip = false;
    public bool playerIsDead = false;
    
    private static GameManager _instance;

    public static GameManager Instance { get { return _instance; } }
    
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        } else {
            _instance = this;
        }
    }

    private void Update()
    {
        if (hasReturnedToShip)
        {
            WinGame();
        }
        else if (playerIsDead)
        {
            LoseGame();
        }
    }

    public void StartGame()
    {
        crewmatesFound = 0;
        crewmatesFoundText.text = "0";
        StartTime();
    }

    private void LoseGame()
    {
        StopTime();
    }

    private void WinGame()
    {
        StopTime();
    }

    private void StopTime()
    {
        Time.timeScale = 0.0f;
    }

    private void StartTime()
    {
        Time.timeScale = 1.0f;
    }

    public void FoundCrewmate()
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
    }
}
