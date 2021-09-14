using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour, IMirror
{
    protected LineRenderer lineRenderer;

    protected Ray ray;
    protected RaycastHit rayHit;
    protected Vector3 rayHitPoint;

    protected Vector3 reflectDirection;
    protected Vector3 hitPoint;
    [SerializeField] protected Transform mirrorTransform;

    /// <summary>
    /// reflects lightbeam from center of mirror
    /// </summary>
    /// <param name="source">vector of the ray that hit</param>
    public void Reflect(Vector3 source)
    {
        if (Physics.Raycast(ray, out rayHit))
        {
            rayHitPoint = rayHit.point;
            RenderLightBeam(mirrorTransform.position, rayHitPoint);
            if (rayHit.collider.tag == "Mirror")
            {
                rayHit.collider.gameObject.GetComponent<IMirror>().Reflect(mirrorTransform.forward, rayHit.point);
            }
            else if (rayHit.collider.tag == "Sensor")
            {
                rayHit.collider.gameObject.GetComponent<ISensor>().Hit();
            }
        }
        else
        {
            RenderLightBeam();
        }
    }

    public void Reflect(Vector3 source, Vector3 hitPos)
    {
        hitPoint = hitPos;
        reflectDirection = Vector3.Reflect(source, mirrorTransform.forward);
        ray = new Ray(hitPos, reflectDirection);

        if (Physics.Raycast(ray, out rayHit))
        {
            rayHitPoint = rayHit.point;
            RenderLightBeam(hitPos, rayHitPoint);
            if (rayHit.collider.tag == "Mirror")
            {
                rayHit.collider.gameObject.GetComponent<IMirror>().Reflect(mirrorTransform.forward, rayHit.point);
            }
        }
        else
        {
            RenderLightBeam(hitPos);
        }
    }

    /// <summary>
    /// draw line to symbolise lightbeam being reflected
    /// </summary>
    protected void RenderLightBeam()
    {
        Vector3[] positions = { hitPoint, mirrorTransform.position + reflectDirection * 3 };
        lineRenderer.SetPositions(positions);
    }

    /// <summary>
    /// draw line to symbolise lightbeam being reflected
    /// </summary>
    /// <param name="hitPos">the point on the mirror that was hit</param>
    protected void RenderLightBeam(Vector3 hitPos)
    {
        Vector3[] positions = { hitPos, mirrorTransform.position + reflectDirection * 3 };
        lineRenderer.SetPositions(positions);
    }

    /// <summary>
    /// draw line to symbolise lightbeam being reflected, and have it stop when another object is hit
    /// </summary>
    /// <param name="hitPos">the point on the mirror that was hit</param>
    /// <param name="rayHitPos">the point that the outgoing ray hit</param>
    protected void RenderLightBeam(Vector3 hitPos, Vector3 rayHitPos)
    {
        Vector3[] positions = { hitPos, rayHitPos };
        lineRenderer.SetPositions(positions);
    }

    /// <summary>
    /// stop rendering the light beam
    /// </summary>
    public void StopBeamRender()
    {
        Vector3[] positions = { hitPoint, hitPoint };
        lineRenderer.SetPositions(positions);
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
}
