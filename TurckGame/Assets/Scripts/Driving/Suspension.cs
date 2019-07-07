using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suspension : MonoBehaviour
{
    public float rimSize = 24f;
    public float tireSection = 0.0f;
    public float tireProfile = 0.0f;

    [Header("Front Axle")]
    public GameObject frontAxle = null;

    public GameObject frontLeft = null;
    public GameObject frontRight = null;

    [Header("Back Axle")]
    public GameObject backAxle = null;

    public GameObject backLeft1_1 = null;
    public GameObject backRight1_1 = null;
    public GameObject backLeft1_2 = null;
    public GameObject backRight1_2 = null;

    [Header("Third Axle")]
    public bool hasThirdAxle = true;
    public GameObject thirdAxle = null;

    public GameObject midLeft1_1 = null;
    public GameObject midRight1_1 = null;
    public GameObject midLeft1_2 = null;
    public GameObject midRight1_2 = null;

    public void ApplyAxles(float currentRPM)
    {
        //Front Axle Stuffs
        float avgFront = (frontLeft.transform.position.y + frontRight.transform.position.y) / 2;

        Vector3 tiresFrontVector = frontLeft.transform.position - frontRight.transform.position;
        float angleFront = Vector3.Angle(tiresFrontVector, new Vector3(frontLeft.transform.position.x, avgFront, frontLeft.transform.position.z));

        frontAxle.transform.rotation = new Quaternion(angleFront, 0, currentRPM * 360f, 0);

        // Back Axle Stuffs
        float avgBack1_1 = (midLeft1_1.transform.position.y + midRight1_1.transform.position.y) / 2;
        float avgBack1_2 = (midLeft1_2.transform.position.y + midRight1_2.transform.position.y) / 2;

        Vector3 tiresBack1_1Vector = (midLeft1_1.transform.position - midRight1_1.transform.position);
        float angleBack1_1 = Vector3.Angle(tiresBack1_1Vector, new Vector3(midLeft1_1.transform.position.x, avgBack1_1, midLeft1_1.transform.position.z));

        Vector3 tiresBack1_2Vector = (midLeft1_2.transform.position - midRight1_2.transform.position);
        float angleBack1_2 = Vector3.Angle(tiresBack1_2Vector, new Vector3(midLeft1_2.transform.position.x, avgBack1_2, midLeft1_2.transform.position.z));

        float avgBackAngle = (angleBack1_1 + angleBack1_2) / 2;

        backAxle.transform.rotation = new Quaternion(avgBackAngle, 0, currentRPM * 360f, 0);

        //Third Axle Stuffs

        if (hasThirdAxle)
        {
            float avgMid1_1 = (midLeft1_1.transform.position.y + midRight1_1.transform.position.y) / 2;
            float avgMid1_2 = (midLeft1_2.transform.position.y + midRight1_2.transform.position.y) / 2;

            Vector3 tires1_1Vector = (midLeft1_1.transform.position - midRight1_1.transform.position);
            float angle1_1 = Vector3.Angle(tires1_1Vector, new Vector3(midLeft1_1.transform.position.x, avgMid1_1, midLeft1_1.transform.position.z));

            Vector3 tires1_2Vector = (midLeft1_2.transform.position - midRight1_2.transform.position);
            float angle1_2 = Vector3.Angle(tires1_2Vector, new Vector3(midLeft1_2.transform.position.x, avgMid1_2, midLeft1_2.transform.position.z));

            float avgAngle = (angle1_1 + angle1_2) / 2;

            thirdAxle.transform.rotation = new Quaternion(avgAngle, 0, currentRPM * 360f, 0);
        }
    }

    public float GetCircumference()
    {
        float sectionHeight = tireSection * tireProfile;
        

        return (sectionHeight * 2) + rimSize;
    }
}
