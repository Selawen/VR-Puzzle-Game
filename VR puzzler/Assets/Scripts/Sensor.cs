using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[ExecuteAlways]
public class Sensor : MonoBehaviour, ISensor
{
    [SerializeField] protected Color sensorColor;
    [SerializeField] protected Color activationColor;
    [SerializeField] protected bool activated = false;

    protected Material mat;

    //update colour of material when changed in inspector
    private void OnValidate()
    {
        mat = gameObject.GetComponent<MeshRenderer>().material;
        mat.color = sensorColor;
    }

    public bool Activated()
    {
        return activated;
    }

    public Color SensorColor()
    {
        return sensorColor;
    }

    public void Hit()
    {
        Debug.Log("I've been hit!");
    }
    
    public void Hit(Color lightColour)
    {
        Debug.Log("I've been hit by:" + lightColour);
    }

    // Start is called before the first frame update
    void Start()
    {
        mat = gameObject.GetComponent<MeshRenderer>().material;
        mat.color = sensorColor;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (activated)
        {
            try
            {
                mat.color = activationColor;
            }
            catch (NullReferenceException ex)
            {
                Debug.Log("mat was not set");
            }
            //mat.color = activationColor;  
        }
        else
        {
            try
            {
                mat.color = sensorColor;
            }
            catch (NullReferenceException ex)
            {
                Debug.Log("mat was not set");
            }
            //mat.color = sensorColor;
        }
    }
}
