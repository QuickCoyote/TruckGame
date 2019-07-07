using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine : MonoBehaviour
{
    public int gear;
    float gearRatio = 0f;
    float horsePower = 0f;
    float torque = 0f;
    float baseMPG = 24f;
    float currentMPG = 0f;
    public float currentRPM = 0;
    float maxRPM = 2200;
    float maxSpeed = 0.0f;

    public float ShiftTimer = 0.5f;

    float currentFuel = 0;
    float maxFuel = 300;

    bool hasEveryPart = true;

    [SerializeField] AnimationCurve HorsePowerCurve = null;
    [SerializeField] AnimationCurve TorqueCurve = null;

    private void Start()
    {
        gear = 0;
        currentRPM = 0;
        currentFuel = maxFuel;
        DetermineGear();
        Shift();
    }

    private void FixedUpdate()
    {
        currentFuel -= 1 / currentMPG;
        horsePower = HorsePowerCurve.Evaluate(currentRPM);
        torque = TorqueCurve.Evaluate(currentRPM);
        Shift();

        if(currentRPM < 1 && currentRPM > -1 && Input.GetAxis("Vertical") == 0)
        {
            currentRPM = 0;
        }

        if(ShiftTimer > 0)
        {
            ShiftTimer -= Time.deltaTime;
        }
    }

    void DetermineGear()
    {

        switch (gear)
        {
            case 0:
                gearRatio = 1;
                maxSpeed = 0;
                break;
            case 1:
                gearRatio = 7f;
                maxSpeed = 5;
                break;
            case 2:
                gearRatio = 6.75f;
                maxSpeed = 10;
                break;
            case 3:
                gearRatio = 6.5f;
                maxSpeed = 15;
                break;
            case 4:
                gearRatio = 6.25f;
                maxSpeed = 20;
                break;
            case 5:
                gearRatio = 6f;
                maxSpeed = 30;
                break;
            case 6:
                gearRatio = 5.75f;
                maxSpeed = 40;
                break;
            case 7:
                gearRatio = 5.5f;
                maxSpeed = 45;
                break;
            case 8:
                gearRatio = 5.25f;
                maxSpeed = 50;
                break;
            case 9:
                gearRatio = 5f;
                maxSpeed = 60;
                break;
            case 10:
                gearRatio = 4.75f;
                maxSpeed = 70;
                break;
            case 11:
                gearRatio = 4.5f;
                maxSpeed = 75;
                break;
            case 12:
                gearRatio = 4.25f;
                maxSpeed = 80;
                break;
            case 13:
                gearRatio = 4.0f;
                maxSpeed = 85;
                break;
        }

        currentMPG = baseMPG / gearRatio;
    }

    public void Shift()
    {
        if (currentRPM >= 1800)
        {
            if (gear < 13)
            {
                gear++;
                ShiftTimer = 0.5f;
                currentRPM = 200;
            }
        }

        if (currentRPM <= 150 && gear != 0)
        {
            if (gear > 1)
            {
                gear--;
                ShiftTimer = 0.5f;
                currentRPM = 200;
            }
        }
    }

    public float getSpeed(float circumference)
    {
        float revolutionsPerMileIN = circumference / 63360;
        float speedPerMinute = currentRPM / revolutionsPerMileIN;

        return (speedPerMinute);
    }

    public float GetGear()
    {
        return gear;
    }

    public float GetGearMinSpeed(int gear)
    {
        float gearVal = 0;

        switch (gear)
        {
            case 0:
                gearVal = 0;
                break;
            case 1:
                gearVal = 1;
                break;
            case 2:
                gearVal = 6;
                break;
            case 3:
                gearVal = 11;
                break;
            case 4:
                gearVal = 16;
                break;
            case 5:
                gearVal = 21;
                break;
            case 6:
                gearVal = 31;
                break;
            case 7:
                gearVal = 41;
                break;
            case 8:
                gearVal = 46;
                break;
            case 9:
                gearVal = 51;
                break;
            case 10:
                gearVal = 61;
                break;
            case 11:
                gearVal = 71;
                break;
            case 12:
                gearVal = 76;
                break;
            case 13:
                gearVal = 81;
                break;
        }

        return gearVal;
    }

    public float GetGearMaxSpeed(int gear)
    {
        float gearVal = 0;

        switch (gear)
        {
            case 0:
                gearVal = 0;
                break;
            case 1:
                gearVal = 5;
                break;
            case 2:
                gearVal = 10;
                break;
            case 3:
                gearVal = 15;
                break;
            case 4:
                gearVal = 20;
                break;
            case 5:
                gearVal = 30;
                break;
            case 6:
                gearVal = 40;
                break;
            case 7:
                gearVal = 45;
                break;
            case 8:
                gearVal = 50;
                break;
            case 9:
                gearVal = 60;
                break;
            case 10:
                gearVal = 70;
                break;
            case 11:
                gearVal = 75;
                break;
            case 12:
                gearVal = 80;
                break;
            case 13:
                gearVal = 85;
                break;
        }

        return gearVal;
    }
}
