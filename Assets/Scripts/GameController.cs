using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private Text lifeCounterText;
    [SerializeField]
    private Text gameOverText;
    [SerializeField]
    private Text gameFinishText;
    [SerializeField]
    private float respawnWait;

    private int lifeCount;

    private PlayerController playerController;


    void Start()
    {
        GameObject playerControllerObject = GameObject.FindWithTag("Player");
        if (playerControllerObject != null)
        {
            playerController = playerControllerObject.GetComponent<PlayerController>();
        }
        if (playerController == null)
        {
            Debug.Log("Cannot find 'PlayerController' script");
        }

        lifeCount = 4;
        gameOverText.text = "";
        gameFinishText.text = "";

        lifeCounterText.text = "Life: " + lifeCount;
    }


    private void GameOver()
    {
        gameOverText.text = "Game Over!";
        Time.timeScale = 0;
    }

    public void Finish()
    {
        gameFinishText.text = "Finish!";
        Time.timeScale = 0;
    }

    public void LoseLife()
    {
        Debug.Log("Life is lost");
        lifeCount--;
        lifeCounterText.text = "Life: " + lifeCount;
        if (lifeCount == 0)
        {
            GameOver();
        }
        else
        {
            playerController.Respawn();
        }
    }
}
