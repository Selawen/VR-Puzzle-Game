using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitterPlane : Mirror, IMirror
{        
    GameObject parent;
    IMirror parentMirror;

    public new void Reflect(Vector3 source, Vector3 hitPos, LineRenderer lightBeam)
    {
        parentMirror.Reflect(source, hitPos, lightBeam);
    }

    private void Start()
    {
        parent = transform.parent.gameObject;
        parent.TryGetComponent<IMirror>(out parentMirror);
        Debug.Log(parent.name);
    }
}
