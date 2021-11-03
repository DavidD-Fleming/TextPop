using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }
}
