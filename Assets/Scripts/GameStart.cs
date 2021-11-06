using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    // start screen
    public GameObject startScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        startScreen.SetActive(false);
        Time.timeScale = 1;

        // restart point counter
        GameObject.Find("Game").GetComponent<PointSystem>().ResetPoints();

        // makes cursor invisible so the player only sees player object
        Cursor.visible = false;
    }
}
