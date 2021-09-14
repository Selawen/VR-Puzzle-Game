using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleMirror : Mirror, IMirror
{
    /// <summary>
    /// reflects lightbeam from center of mirror
    /// </summary>
    /// <param name="source">vector of the ray that hit</param>
    public new void Reflect(Vector3 source)
    {
        reflectDirection = Vector3.Reflect(source, mirrorTransform.forward);
        base.Reflect(source);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
