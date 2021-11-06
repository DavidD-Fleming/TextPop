using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using TMPro;

public class Hazard : MonoBehaviour
{
    // smarter dimensions
    Vector2 screenHalfSizeWorldUnits;
    Vector2 halfHazardSize;
    
    // speed
    public Vector2 speedMinMax;
    float speed;

    // color & trail
    Shader hazardShader;
    public int trailEndWidth;

    // detonation letter
    char detonationKey;

    // Start is called before the first frame update
    void Start()
    {
        // setting detonation code
        char[] letterBank = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
        // ;)
        int letterKey = Random.Range(0, 35);
        detonationKey = letterBank[letterKey];
        TextMeshPro letterText = transform.GetChild(1).GetComponent<TextMeshPro>();
        letterText.text = "" + detonationKey;

        // setting dimensions
        screenHalfSizeWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
        halfHazardSize = new Vector2(transform.localScale.x / 2f, transform.localScale.y / 2f);

        // set speed
        if (DifficultySetting.ReturnDifficulty() == 2)
        {
            speed = speedMinMax.y;
        } else
        {
            speed = Mathf.Lerp(speedMinMax.x, speedMinMax.y, Difficulty.GetDifficultyPercent());
        }

        // determine color based on numbers
        byte redValue = (byte)Mathf.Lerp(0, 255, Difficulty.GetDifficultyPercent());
        byte greenValue = (byte)Mathf.Lerp(255, 0, Mathf.Clamp01(speed / speedMinMax.y));
        byte blueValue = (byte)(255 - letterKey * 7);

        // set color
        hazardShader = Shader.Find("Unlit/Color");
        var hazardRenderer = transform.GetComponent<Renderer>();
        hazardRenderer.material.shader = hazardShader;
        hazardRenderer.material.SetColor("_Color", new Color32(redValue, greenValue, blueValue, 0));

        // set trail
        TrailRenderer hazardTrail = transform.GetChild(0).GetComponent<TrailRenderer>();
        hazardTrail.startColor = new Color32(redValue, greenValue, blueValue, 255);
        hazardTrail.endColor = new Color32(0, 0, 0, 0);
        hazardTrail.endWidth = trailEndWidth;
        // trail length is done at Spawner.cs to be adjustable relative to hazard size. Bad code!
    }

    // Update is called once per frame
    void Update()
    {
        // hazards go up
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        // bounce if hazard is on the edge
        if (transform.position.x < -screenHalfSizeWorldUnits.x)
        {
            transform.position = new Vector2(-screenHalfSizeWorldUnits.x, transform.position.y);
            transform.eulerAngles = new Vector3(0, 0, -transform.eulerAngles.z);
        }
        if (transform.position.x > screenHalfSizeWorldUnits.x)
        {
            transform.position = new Vector2(screenHalfSizeWorldUnits.x, transform.position.y);
            transform.eulerAngles = new Vector3(0, 0, -transform.eulerAngles.z);
        }
        if (transform.position.y < -screenHalfSizeWorldUnits.y)
        {
            transform.position = new Vector2(transform.position.x, -screenHalfSizeWorldUnits.y);
            transform.eulerAngles = new Vector3(0, 0, 180 - transform.eulerAngles.z);
        }
        if (transform.position.y > screenHalfSizeWorldUnits.y)
        {
            transform.position = new Vector2(transform.position.x, screenHalfSizeWorldUnits.y);
            transform.eulerAngles = new Vector3(0, 0, 180 - transform.eulerAngles.z);
        }
    }

    void OnGUI()
    {
        // destorys object if detonation key is pressed
        // needs to have score go down when a random key is pressed to avoid key spamming
        if (Event.current.Equals(Event.KeyboardEvent(detonationKey + "")))
        {
            Destroy(gameObject);
        }
    }
}
