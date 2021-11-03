using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockRotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // locks rotation so text is always upright
        var rotation = Quaternion.LookRotation(Vector3.forward);
        transform.rotation = rotation;
    }
}
