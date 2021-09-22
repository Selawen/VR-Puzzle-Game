using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class ColouredLightSensor : LightSensor, ISensor
{
    private Material mat;

    public new void Hit(Color lightColour)
    {
        if (lightColour == sensorColor)
        {
            base.Hit();
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    //update colour of material when changed in inspector
    private void OnValidate()
    {
        mat = GetComponent<MeshRenderer>().material;
        mat.color = sensorColor;
    }

}
