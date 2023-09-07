using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spin : MonoBehaviour
{
    public float rotationSpeed = 0.1f;
    public float brrcnt = 0;
    public float level = 30;

    void Start()
    {

    }

    void Update()
    {
        if (brrcnt <= -level || brrcnt >= level) brrcnt = -level + 2;
        else brrcnt++;
        transform.Rotate(brrcnt * Time.deltaTime, brrcnt * Time.deltaTime, brrcnt * Time.deltaTime);


    }
}
