using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject player;
    public bool playerIsDead = false;
    private bool _gameIsPaused;

    private void Start()
    {
        _gameIsPaused = false;
        pauseMenu.SetActive(false);
    }

    private void Update()
    {
        if (player.GetComponent<Respawn>().currentLife <= 0)
        {
            playerIsDead = true;
        }
        if (playerIsDead)
        {
            Pause();
        }
    }

    public void Pause()
    {
        if (Time.timeScale == 0 && !playerIsDead && _gameIsPaused)
        {
            _gameIsPaused = false;
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }
        else if(!_gameIsPaused)
        {
            _gameIsPaused = true;
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
        
    }
}
