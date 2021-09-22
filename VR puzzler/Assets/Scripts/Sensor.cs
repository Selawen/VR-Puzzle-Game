using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour, ISensor
{
    [SerializeField] protected Color sensorColor;
    [SerializeField] protected bool activated = false;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
