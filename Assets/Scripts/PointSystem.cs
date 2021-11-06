using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointSystem : MonoBehaviour
{
    // score text
    public TextMeshProUGUI gameOverScoreText;
    public TextMeshProUGUI playingScoreText;

    static float points;
    public float removePointsNumber;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        points += 1;
        gameOverScoreText.text = points.ToString("N0") + "P";

        // shows playingScore if enabled
        if (ZPlayerPrefs.GetInt("ScoresOn") == 0)
        {
            playingScoreText.text = "";
        }
        else
        {
            playingScoreText.text = points.ToString("N0") + "P";
        }

        // minus points everytime player presses a key
        if (Input.anyKey)
        {
            points -= removePointsNumber;
        }
    }

    public static float ReturnPoints()
    {
        return points;
    }

    public void ResetPoints()
    {
        points = 0;
    }
}
