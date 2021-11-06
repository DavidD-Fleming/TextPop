using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DifficultySetting : MonoBehaviour
{
    // difficulty indicator
    public TextMeshProUGUI difficultyText;

    static int difficulty = 0;

    public void SetDifficultyToEasy()
    {
        difficulty = 0;
        difficultyText.text = "Easy";
    }

    public void SetDifficultyToMedium()
    {
        difficulty = 1;
        difficultyText.text = "Medium";
    }

    public void SetDifficultyToHard()
    {
        difficulty = 2;
        difficultyText.text = "Hard";
    }

    public static int ReturnDifficulty()
    {
        return difficulty;
    }
}
