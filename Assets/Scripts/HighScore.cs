using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class HighScore : MonoBehaviour
{
    // high score texts
    public TextMeshProUGUI easyScoreText;
    public TextMeshProUGUI mediumScoreText;
    public TextMeshProUGUI hardScoreText;

    // Start is called before the first frame update
    void Start()
    {
        ZPlayerPrefs.Initialize("Lemon", "SLStan0002!");
        InitializeZPP();
    }

    // initializes settings with specified settings
    public void InitializeZPP(int volumeHolder, int trailHolder, int scoreHolder)
    {
        if (!ZPlayerPrefs.HasKey("EasyScore"))
        {
            ZPlayerPrefs.SetFloat("EasyScore", 0);
        }
        if (!ZPlayerPrefs.HasKey("MediumScore"))
        {
            ZPlayerPrefs.SetFloat("MediumScore", 0);
        }
        if (!ZPlayerPrefs.HasKey("HardScore"))
        {
            ZPlayerPrefs.SetFloat("HardScore", 0);
        }
        if (!ZPlayerPrefs.HasKey("VolumeOn"))
        {
            ZPlayerPrefs.SetInt("VolumeOn", volumeHolder);
        }
        if (!ZPlayerPrefs.HasKey("TrailsOn"))
        {
            ZPlayerPrefs.SetInt("TrailsOn", trailHolder);
        }
        if (!ZPlayerPrefs.HasKey("ScoresOn"))
        {
            ZPlayerPrefs.SetInt("ScoresOn", scoreHolder);
        }
    }

    // initializes settings without specified settings
    public void InitializeZPP()
    {
        if (!ZPlayerPrefs.HasKey("EasyScore"))
        {
            ZPlayerPrefs.SetFloat("EasyScore", 0);
        }
        if (!ZPlayerPrefs.HasKey("MediumScore"))
        {
            ZPlayerPrefs.SetFloat("MediumScore", 0);
        }
        if (!ZPlayerPrefs.HasKey("HardScore"))
        {
            ZPlayerPrefs.SetFloat("HardScore", 0);
        }
        if (!ZPlayerPrefs.HasKey("VolumeOn"))
        {
            ZPlayerPrefs.SetInt("VolumeOn", 1);
        }
        if (!ZPlayerPrefs.HasKey("TrailsOn"))
        {
            ZPlayerPrefs.SetInt("TrailsOn", 1);
        }
        if (!ZPlayerPrefs.HasKey("ScoresOn"))
        {
            ZPlayerPrefs.SetInt("ScoresOn", 1);
        }
    }

    public void Reset()
    {
        // keeps changes to volume, trail, and score settings
        int volumeHolder = ZPlayerPrefs.GetInt("VolumeOn");
        int trailHolder = ZPlayerPrefs.GetInt("TrailsOn");
        int scoreHolder = ZPlayerPrefs.GetInt("ScoresOn");

        ZPlayerPrefs.DeleteAll();
        InitializeZPP(volumeHolder, trailHolder, scoreHolder);
        SceneManager.LoadScene(0);
    }

    public void UpdateHighScores()
    {
        // find current difficulty and compare scores of that difficulty
        float currentScore = PointSystem.ReturnPoints();
        int difficulty = DifficultySetting.ReturnDifficulty();
        if (difficulty == 0)
        {
            if (currentScore >= ZPlayerPrefs.GetFloat("EasyScore"))
            {
                ZPlayerPrefs.SetFloat("EasyScore", currentScore);
            }
        } else if (difficulty == 1)
        {
            if (currentScore >= ZPlayerPrefs.GetFloat("MediumScore"))
            {
                ZPlayerPrefs.SetFloat("MediumScore", currentScore);
            }
        } else
        {
            if (currentScore >= ZPlayerPrefs.GetFloat("HardScore"))
            {
                ZPlayerPrefs.SetFloat("HardScore", currentScore);
            }
        }

        // update high score text
        easyScoreText.text = ZPlayerPrefs.GetFloat("EasyScore").ToString("N0") + "P";
        mediumScoreText.text = ZPlayerPrefs.GetFloat("MediumScore").ToString("N0") + "P";
        hardScoreText.text = ZPlayerPrefs.GetFloat("HardScore").ToString("N0") + "P";
    }
}
