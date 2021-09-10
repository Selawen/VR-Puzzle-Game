using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleMirror : MonoBehaviour, IMirror
{
    private LineRenderer lineRenderer;

    private Ray ray;
    private RaycastHit rayHit;
    private Vector3 rayHitPoint;

    private Vector3 reflectDirection;
    private Vector3 hitPoint;
    [SerializeField] private Transform mirrorTransform;

    /// <summary>
    /// reflects lightbeam from center of mirror
    /// </summary>
    /// <param name="source">vector of the ray that hit</param>
    public void Reflect(Vector3 source)
    {
        //Debug.Log(Vector3.Angle(source, mirrorTransform.forward));
        if (Vector3.Angle(source, mirrorTransform.forward) < 90)
        {
            reflectDirection = Vector3.Reflect(source, mirrorTransform.forward);
            if (Physics.Raycast(ray, out rayHit))
            {
                rayHitPoint = rayHit.point;
                RenderLightBeam(mirrorTransform.position, rayHitPoint);
                if (rayHit.collider.tag == "Mirror")
                {
                    rayHit.collider.gameObject.GetComponent<IMirror>().Reflect(mirrorTransform.forward, rayHit.point);
                }
            }
            else
            {
                RenderLightBeam();
            }
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
    public void Reflect(Vector3 source, Vector3 hitPos)
    {
        //Debug.Log(Vector3.Angle(source, mirrorTransform.forward));
        hitPoint = hitPos;
        if (Vector3.Angle(source, mirrorTransform.forward) < 90)
        {
            Debug.Log(gameObject.name + " Hit at: " + hitPos);
            reflectDirection = Vector3.Reflect(source, mirrorTransform.forward);
            ray = new Ray(hitPos, reflectDirection);
            if (Physics.Raycast(ray, out rayHit))
            {
                rayHitPoint = rayHit.point;
                RenderLightBeam(hitPos, rayHitPoint);
                if (rayHit.collider.tag == "Mirror")
                {
                    rayHit.collider.gameObject.GetComponent<IMirror>().Reflect(reflectDirection, rayHit.point);
                }
            }
            else
            {
                RenderLightBeam(hitPos);
            }
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

    /// <summary>
    /// draw line to symbolise lightbeam being reflected
    /// </summary>
    void RenderLightBeam()
    {
        Vector3[] positions = { mirrorTransform.position, mirrorTransform.position + reflectDirection * 3 };
        lineRenderer.SetPositions(positions);
    }

    /// <summary>
    /// draw line to symbolise lightbeam being reflected
    /// </summary>
    /// <param name="hitPos">the point on the mirror that was hit</param>
    void RenderLightBeam(Vector3 hitPos)
    {
        Vector3[] positions = { hitPos, mirrorTransform.position + reflectDirection * 3 };
        lineRenderer.SetPositions(positions);
    }

    /// <summary>
    /// draw line to symbolise lightbeam being reflected, and have it stop when another object is hit
    /// </summary>
    /// <param name="hitPos">the point on the mirror that was hit</param>
    /// <param name="rayHitPos">the point that the outgoing ray hit</param>
    void RenderLightBeam(Vector3 hitPos, Vector3 rayHitPos)
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
}
