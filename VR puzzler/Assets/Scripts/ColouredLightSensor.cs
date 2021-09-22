using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColouredLightSensor : Sensor, ISensor
{
    private bool hit = false;

    public new void Hit()
    {
        hit = true;
    }
    
    public new void Hit(Color ligntColour)
    {
        hit = true;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!activated && hit)
        {
            activated = true;
            hit = false;
        } else if (activated && !hit)
        {
            activated = false;
        }
    }


}
