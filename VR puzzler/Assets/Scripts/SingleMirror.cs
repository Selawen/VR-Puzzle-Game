using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleMirror : MonoBehaviour, IMirror
{
    private LineRenderer lineRenderer;

    private Vector3 reflectDirection;
    private Vector3 hitPoint;
    [SerializeField] private Transform mirrorTransform;

    public void Reflect(Vector3 source)
    {
        //Debug.Log(Vector3.Angle(source, mirrorTransform.forward));
        if (Vector3.Angle(source, mirrorTransform.forward) < 90)
        {
            reflectDirection = Vector3.Reflect(source, mirrorTransform.forward);
            RenderLightBeam();
        } else
        {
            StopBeamRender();
        }
    }

    public void Reflect(Vector3 source, Vector3 hitPos)
    {
        //Debug.Log(Vector3.Angle(source, mirrorTransform.forward));
        hitPoint = hitPos;
        if (Vector3.Angle(source, mirrorTransform.forward) < 90)
        {
            reflectDirection = Vector3.Reflect(source, mirrorTransform.forward);
            RenderLightBeam(hitPos);
        } else
        {
            StopBeamRender();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = gameObject.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void RenderLightBeam()
    {
        Vector3[] positions = { mirrorTransform.position, mirrorTransform.position + reflectDirection * 3 };
        lineRenderer.SetPositions(positions);
    }

    void RenderLightBeam(Vector3 hitPoint)
    {
        Vector3[] positions = { hitPoint, mirrorTransform.position + reflectDirection * 3 };
        lineRenderer.SetPositions(positions);
    }

    void StopBeamRender()
    {
        Vector3[] positions = { hitPoint, hitPoint };
        lineRenderer.SetPositions(positions);
    }
}
