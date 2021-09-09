using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleMirror : MonoBehaviour, IMirror
{
    private LineRenderer lineRenderer;

    private Vector3 reflectDirection;
    [SerializeField] private Transform mirrorTransform;

    public void Reflect(Vector3 source)
    {
        reflectDirection = Vector3.Reflect(source, mirrorTransform.forward);
        RenderLightBeam();
    }

    public void Reflect(Vector3 source, Vector3 hitPos)
    {
        reflectDirection = Vector3.Reflect(source, mirrorTransform.forward);
        RenderLightBeam(hitPos);
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
}
