using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMirror
{
    void Reflect(Vector3 source);
    void Reflect(Vector3 source, Vector3 hitPos);
}
