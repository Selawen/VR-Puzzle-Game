using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSensor : Sensor, ISensor
{
    private bool hit = false;

    public new void Hit()
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
        } else if (activated && !hit)
        {
            activated = false;
        }
        hit = false;
    }


}
