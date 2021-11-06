using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // smarter dimensions
    Vector2 screenHalfSizeWorldUnits;

    // Hazard
    public GameObject hazardPrefab;
    public Vector2 spawnTimeMinMax;
    public Vector2 spawnSizeMinMax;
    public float spawnAngleMax;
    float nextSpawnTime;
    GameObject newHazard;
    float spawnTime;

    // trail
    public int trailLength;

    // Start is called before the first frame update
    void Start()
    {
        // setting dimensions
        screenHalfSizeWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }

    // Update is called once per frame
    void Update()
    {
        if (nextSpawnTime < Time.time)
        {
            // spawning time
            if (DifficultySetting.ReturnDifficulty() == 0)
            {
                spawnTime = Mathf.Lerp(spawnTimeMinMax.y, spawnTimeMinMax.x, Difficulty.GetDifficultyPercent());
            } else if (DifficultySetting.ReturnDifficulty() == 1)
            {
                spawnTime = Mathf.Lerp((spawnTimeMinMax.y + spawnTimeMinMax.x) / 2, spawnTimeMinMax.x, Difficulty.GetDifficultyPercent());
            } else
            {
                spawnTime = spawnTimeMinMax.x;
            }
            nextSpawnTime = Time.time + spawnTime;

            // spawning attributes
            float spawnAngle = Random.Range(-spawnAngleMax, spawnAngleMax);
            float spawnSize = Random.Range(spawnSizeMinMax.x, spawnSizeMinMax.y);
            int spawnStart = Random.Range(0, 4);
            if (spawnStart == 0)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-screenHalfSizeWorldUnits.x, screenHalfSizeWorldUnits.x), 2 * screenHalfSizeWorldUnits.y + spawnSize / 2);
                newHazard = (GameObject)Instantiate(hazardPrefab, spawnPosition, Quaternion.Euler(Vector3.back * spawnAngle));
                //Debug.Log("0");
            } else if (spawnStart == 1)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-screenHalfSizeWorldUnits.x, screenHalfSizeWorldUnits.x), -2 * screenHalfSizeWorldUnits.y - spawnSize / 2);
                newHazard = (GameObject)Instantiate(hazardPrefab, spawnPosition, Quaternion.Euler(Vector3.forward * spawnAngle));
                //Debug.Log("1");
            } else if (spawnStart == 2)
            {
                Vector3 spawnPosition = new Vector3(-2 * screenHalfSizeWorldUnits.x - spawnSize / 2, Random.Range(-screenHalfSizeWorldUnits.y, screenHalfSizeWorldUnits.y));
                newHazard = (GameObject)Instantiate(hazardPrefab, spawnPosition, Quaternion.Euler(Vector3.forward * spawnAngle));
                //Debug.Log("2");
            } else
            {
                Vector3 spawnPosition = new Vector3(2 * screenHalfSizeWorldUnits.x + spawnSize / 2, Random.Range(-screenHalfSizeWorldUnits.y, screenHalfSizeWorldUnits.y));
                newHazard = (GameObject)Instantiate(hazardPrefab, spawnPosition, Quaternion.Euler(Vector3.forward * spawnAngle));
                //Debug.Log("3");
            }
            newHazard.transform.localScale = Vector2.one * spawnSize;
            // adjust trail width and time to match hazard size
            if (ZPlayerPrefs.GetInt("TrailsOn") == 1)
            {
                newHazard.transform.GetChild(0).GetComponent<TrailRenderer>().time = trailLength / spawnSize;
            }
            else
            {
                newHazard.transform.GetChild(0).GetComponent<TrailRenderer>().time = 0;
            }
            newHazard.transform.GetChild(0).GetComponent<TrailRenderer>().startWidth = spawnSize;
        }
    }
}
