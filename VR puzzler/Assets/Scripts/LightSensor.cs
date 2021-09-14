using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSensor : MonoBehaviour, ISensor
{
    [SerializeField] private Color sensorColor;

    public Color SensorColor()
    {
        return sensorColor;
    }

    public void Hit()
    {
        Debug.Log("I've been hit!");
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
