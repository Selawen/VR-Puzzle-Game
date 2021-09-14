using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleMirror : Mirror, IMirror
{    /// <summary>
    /// reflects lightbeam from center of mirror
    /// </summary>
    /// <param name="source">vector of the ray that hit</param>
    public new void Reflect(Vector3 source)
    {
        if (Vector3.Angle(source, mirrorTransform.forward) < 90)
        {
            reflectDirection = Vector3.Reflect(source, mirrorTransform.forward);
            base.Reflect(source);
        } else
        {
            StopBeamRender();
        }
    }

    /// <summary>
    /// reflects lightbeam and sends out new ray with it
    /// </summary>
    /// <param name="source">the vector of the ray that hit the mirror</param>
    /// <param name="hitPos">the point that the ray hit the mirror</param>
    public new void Reflect(Vector3 source, Vector3 hitPos)
    {
        hitPoint = hitPos;
        if (Vector3.Angle(source, mirrorTransform.forward) < 90)
        {
            base.Reflect(source, hitPos);
        } else
        {
            StopBeamRender();
        }
    }
}
