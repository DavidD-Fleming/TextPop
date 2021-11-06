using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    // dimensions
    /*
    float screenHalfWidthInWorldUnits;
    float screenHalfHeightInWorldUnits;
    */

    // Start is called before the first frame update
    void Start()
    {
        // start time at 0
        Time.timeScale = 0;

        // set aspect ratio
        // Screen.SetResolution(1600, 900, true);
        Screen.fullScreen = false;

        // set dimensions
        /*
        screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize - halfPlayerWidth;
        screenHalfHeightInWorldUnits = Camera.main.orthographicSize - halfPlayerHeight;
        */
    }

    // Update is called once per frame
    void Update()
    {
        // prevents cursor movement out of screen
        /*
        if (Cursor.position.x < -screenHalfWidthInWorldUnits)
        {
            Cursor.position = new Vector2(-screenHalfWidthInWorldUnits, Cursor.position.y);
        }
        if (Cursor.position.x > screenHalfWidthInWorldUnits)
        {
            Cursor.position = new Vector2(screenHalfWidthInWorldUnits, Cursor.position.y);
        }
        if (Cursor.position.y < -screenHalfHeightInWorldUnits)
        {
            Cursor.position = new Vector2(Cursor.position.x, -screenHalfHeightInWorldUnits);
        }
        if (Cursor.position.y > screenHalfHeightInWorldUnits)
        {
            Cursor.position = new Vector2(Cursor.position.x, screenHalfHeightInWorldUnits);
        }
        */
    }
}
