using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SettingsManager : MonoBehaviour
{
    // settings variables are set in HighScore.cs

    // settings gameobjects
    public GameObject player;
    public GameObject settingsScreen;
    public GameObject resetScreen;
    public GameObject guideScreen;
    public TextMeshProUGUI volumeText;
    public TextMeshProUGUI trailsText;
    public TextMeshProUGUI scoresText;
    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        // set audiosource
        audio = GetComponent<AudioSource>();

        // check buttons are in correct form (may be pointless :o)
        if (ZPlayerPrefs.GetInt("VolumeOn") == 1)
        {
            volumeText.text = "O";
            audio.mute = false;
        }
        else
        {
            volumeText.text = "X";
            audio.mute = true;
        }
        if (ZPlayerPrefs.GetInt("TrailsOn") == 1)
        {
            trailsText.text = "O";
        }
        else
        {
            trailsText.text = "X";
        }
        if (ZPlayerPrefs.GetInt("ScoresOn") == 1)
        {
            scoresText.text = "O";
        }
        else
        {
            scoresText.text = "X";
        }
    }

    // Update is called once per frame
    void Update()
    {
        // turns player object on for reasons
        if (Input.GetKey(KeyCode.D))
        {
            player.SetActive(true);
        }
    }

    public void CloseSettings()
    {
        settingsScreen.SetActive(false);
    }

    public void OpenSettings()
    {
        settingsScreen.SetActive(true);
    }

    public void CloseReset()
    {
        resetScreen.SetActive(false);
    }

    public void OpenReset()
    {
        resetScreen.SetActive(true);
    }

    public void CloseGuide()
    {
        guideScreen.SetActive(false);
    }

    public void OpenGuide()
    {
        guideScreen.SetActive(true);
    }

    // secret button so I can show off
    public void MakePlayerInvisible()
    {
        player.SetActive(false);
    }

    // resets everything from highscore script
    /*
    public void ResetEverything()
    {
        GameObject.Find("Game").GetComponent<HighScore>().Reset();
    }
    */

    // ALL VOLUME, TRAILS, AND SCORES ARE INITIALIZED IN HIGHSCORE

    public void VolumeOnOff()
    {
        // flips the value of volume and shows it on button
        if (ZPlayerPrefs.GetInt("VolumeOn") == 0)
        {
            ZPlayerPrefs.SetInt("VolumeOn", 1);
        }
        else
        {
            ZPlayerPrefs.SetInt("VolumeOn", 0);
        }
        if (ZPlayerPrefs.GetInt("VolumeOn") == 1)
        {
            volumeText.text = "O";
            audio.mute = false;
        }
        else
        {
            volumeText.text = "X";
            audio.mute = true;
        }


    }

    public void TrailsOnOff()
    {
        // flips the value of trails and shows it on button
        if (ZPlayerPrefs.GetInt("TrailsOn") == 0)
        {
            ZPlayerPrefs.SetInt("TrailsOn", 1);
        }
        else
        {
            ZPlayerPrefs.SetInt("TrailsOn", 0);
        }
        if (ZPlayerPrefs.GetInt("TrailsOn") == 1)
        {
            trailsText.text = "O";
        } else
        {
            trailsText.text = "X";
        }
    }

    public void ScoresOnOff()
    {
        // flips the value of scores and shows it on button
        if (ZPlayerPrefs.GetInt("ScoresOn") == 0)
        {
            ZPlayerPrefs.SetInt("ScoresOn", 1);
        }
        else
        {
            ZPlayerPrefs.SetInt("ScoresOn", 0);
        }
        if (ZPlayerPrefs.GetInt("ScoresOn") == 1)
        {
            scoresText.text = "O";
        }
        else
        {
            scoresText.text = "X";
        }
    }
}
