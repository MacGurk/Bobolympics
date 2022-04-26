using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject respawnButton;

    private GameController gameController;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    void Update()
    {
        if (!gameController.IsGameOver())
        {
            respawnButton.SetActive(true);
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                if (GameIsPaused)
                {
                    Resume();
                }
                else
                {
                    Paused();
                }
            }
        }
        else
        {
            respawnButton.SetActive(false);
        }
        
        
    }

    void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Paused()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void RestartButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void RespawnButton()
    {
        Time.timeScale = 1f;
        gameController.LoseLife();
        Resume();
    }
}
