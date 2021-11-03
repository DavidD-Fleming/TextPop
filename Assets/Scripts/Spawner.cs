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
            float spawnTime = Mathf.Lerp(spawnTimeMinMax.y, spawnTimeMinMax.x, Difficulty.GetDifficultyPercent());
            nextSpawnTime = Time.time + spawnTime;

            // spawning attributes
            float spawnAngle = Random.Range(-spawnAngleMax, spawnAngleMax);
            float spawnSize = Random.Range(spawnSizeMinMax.x, spawnSizeMinMax.y);
            Vector3 spawnPosition = new Vector3(Random.Range(-screenHalfSizeWorldUnits.x, screenHalfSizeWorldUnits.x), Random.Range(-screenHalfSizeWorldUnits.y, screenHalfSizeWorldUnits.y));

            // actually spawn hazard w/ set or unset attributes
            GameObject newHazard = (GameObject)Instantiate(hazardPrefab, spawnPosition, Quaternion.Euler(Vector3.forward * spawnAngle));
            newHazard.transform.localScale = Vector2.one * spawnSize;
            // adjust trail width and time to match hazard size
            newHazard.transform.GetChild(0).GetComponent<TrailRenderer>().startWidth = spawnSize;
            newHazard.transform.GetChild(0).GetComponent<TrailRenderer>().time = trailLength / spawnSize;
        }
    }
}
