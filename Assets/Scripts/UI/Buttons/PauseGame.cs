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
        player.GetComponent<Respawn>().PlayerIsDead += PlayerIsDead;
    }

    private void Update()
    {
        if (playerIsDead)
        {
            Pause();
        }
    }
    private void PlayerIsDead(bool a)
    {
        playerIsDead = a;
        player.GetComponent<Respawn>().PlayerIsDead -= PlayerIsDead;
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
