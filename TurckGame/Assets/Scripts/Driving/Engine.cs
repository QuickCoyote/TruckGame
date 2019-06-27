using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine : MonoBehaviour
{
    float gearRatio = 1.0f;
    float horsePower = 100.0f;
    float torque = 100.0f;
    float fuelConsumption = 1.0f;

    bool hasEveryPart = true;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasEveryPart)
        {
            horsePower = 0;
            torque = 0;
        }
    }
}
