using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector2 mousePosition;

    // dimensions
    float screenHalfWidthInWorldUnits;
    float screenHalfHeightInWorldUnits;
    float halfPlayerWidth;
    float halfPlayerHeight;

    // trail
    TrailRenderer playerTrail;
    public int trailEndWidth;
    public float trailLength;

    // Start is called before the first frame update
    void Start()
    {
        // set dimensions
        halfPlayerWidth = transform.localScale.x / 2f;
        halfPlayerHeight = transform.localScale.y / 2f;
        screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize - halfPlayerWidth;
        screenHalfHeightInWorldUnits = Camera.main.orthographicSize - halfPlayerHeight;

        // set trail
        playerTrail = transform.GetChild(0).GetComponent<TrailRenderer>();
        playerTrail.startColor = new Color32(255, 255, 255, 255);
        playerTrail.endColor = new Color32(0, 0, 0, 0);
        playerTrail.endWidth = trailEndWidth;
        playerTrail.startWidth = 0.75f;
        // set trail length in update
    }

    // Update is called once per frame
    void Update()
    {
        // player follows mouse
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = mousePosition;

        // prevents movement out of screen
        if (transform.position.x < -screenHalfWidthInWorldUnits)
        {
            transform.position = new Vector2(-screenHalfWidthInWorldUnits, transform.position.y);
        }
        if (transform.position.x > screenHalfWidthInWorldUnits)
        {
            transform.position = new Vector2(screenHalfWidthInWorldUnits, transform.position.y);
        }
        if (transform.position.y < -screenHalfHeightInWorldUnits)
        {
            transform.position = new Vector2(transform.position.x, -screenHalfHeightInWorldUnits);
        }
        if (transform.position.y > screenHalfHeightInWorldUnits)
        {
            transform.position = new Vector2(transform.position.x, screenHalfHeightInWorldUnits);
        }

        // set trails on or off
        if (ZPlayerPrefs.GetInt("TrailsOn") == 1)
        {
            playerTrail.time = trailLength;
        }
        else
        {
            playerTrail.time = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D triggerCollider)
    {
        GameObject.Find("Game").GetComponent<GameOver>().OnGameOver();
    }
}
