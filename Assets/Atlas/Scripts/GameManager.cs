using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int crewmatesFound = 0;
    public int crewmatesTotal = 5;
    
    public Text crewmatesFoundText;
    public Text returnToSpaceShipText;
    public Text winLoseText;

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

    private void Start()
    {
        StartGame();
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
        crewmatesFoundText.text = crewmatesTotal.ToString();
        CleanUI();
        StartTime();
    }

    private void LoseGame()
    {
        CleanUI();
        winLoseText.text = "Game Over\nPress Enter / Pause to play again";
        winLoseText.enabled = true;
        StopTime();
    }

    private void WinGame()
    {
        CleanUI();
        winLoseText.text = "You win!\nPress Enter / Pause to play again";
        winLoseText.enabled = true;
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

    private void CleanUI()
    {
        winLoseText.enabled = false;
        returnToSpaceShipText.enabled = false;
    }

    public void FoundCrewmate()
    {
        crewmatesFound++;
        crewmatesFoundText.text = (crewmatesTotal - crewmatesFound).ToString();
        if (crewmatesFound >= crewmatesTotal)
        {
            // Separate audio for finding all crewmates? 
            allCrewmatesFound = true;
            returnToSpaceShipText.enabled = true;
        }
        else
        {
            // PLay default audio
            Debug.Log("Henlo");
        }
    }

    public static void RestartGame()
    {
        if (Time.timeScale <= 0.01f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
