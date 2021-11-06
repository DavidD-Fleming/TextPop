using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // game over screen
    public GameObject gameOverScreen;

    bool isGameOver;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnGameOver()
    {
        Time.timeScale = 0;
        isGameOver = true;
        gameOverScreen.SetActive(true);
        Cursor.visible = true;

        // destroy all hazards (hazards cover canvas, easier solution then to rework canvas)
        var hazards = GameObject.FindGameObjectsWithTag("Hazard");
        foreach (var hazard in hazards)
        {
            Destroy(hazard);
        }

        GameObject.Find("Game").GetComponent<HighScore>().UpdateHighScores();
    }

    public void PlayAgain()
    {
        // restarts scene
        if (isGameOver)
        {
            SceneManager.LoadScene(0);
        }
    }
}
