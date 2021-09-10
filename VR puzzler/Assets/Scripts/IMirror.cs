using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMirror
{
    /// <summary>
    /// reflects lightbeam from center of mirror
    /// </summary>
    /// <param name="source">vector of the ray that hit</param>
    void Reflect(Vector3 source);

    /// <summary>
    /// reflects lightbeam and sends out new ray with it
    /// </summary>
    /// <param name="source">the vector of the ray that hit the mirror</param>
    /// <param name="hitPos">the point that the ray hit the mirror</param>
    void Reflect(Vector3 source, Vector3 hitPos);

    /// <summary>
    /// stop rendering the light beam
    /// </summary>
    void StopBeamRender();
}
