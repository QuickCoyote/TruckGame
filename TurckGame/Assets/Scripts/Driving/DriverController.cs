using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriverController : MonoBehaviour
{
    [SerializeField] Suspension suspension = null;
    [SerializeField] Engine engine = null;

    void Start()
    {
        
    }
    void Update()
    {
        suspension.ApplyAxles(engine.currentRPM);

        if(Input.GetAxis("Vertical") != 0 && engine.ShiftTimer <= 0)
        {
            if(engine.currentRPM == 0)
            {
                engine.gear++;
            }
            engine.currentRPM += Time.deltaTime * Input.GetAxis("Vertical") * (300 * (13/engine.GetGear()));
        }

        transform.position += (transform.forward * Mathf.Clamp(engine.getSpeed(suspension.GetCircumference()), engine.GetGearMinSpeed((int)engine.GetGear()), engine.GetGearMaxSpeed((int)engine.GetGear())) / 100);

        Debug.Log("Speed (MPH): " + engine.getSpeed(suspension.GetCircumference()));
    }
}
