using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISensor
{
    Color SensorColor();
    bool Activated();
    void Hit();
    void Hit(Color lightColour);
}
