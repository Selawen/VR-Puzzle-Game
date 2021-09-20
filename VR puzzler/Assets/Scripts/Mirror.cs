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
                rayHit.collider.gameObject.GetComponent<IMirror>().Reflect(reflectDirection, rayHit.point);
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

        if (Vector3.SignedAngle(source, mirrorTransform.forward, mirrorTransform.forward) < 90)
        {
            reflectDirection = Vector3.Reflect(source, mirrorTransform.forward);
        } else
        {
            reflectDirection = Vector3.Reflect(source, mirrorTransform.forward*-1);
        }

        //Debug.Log(reflectDirection);

        ray = new Ray(hitPos, reflectDirection);

        if (Physics.Raycast(ray, out rayHit))
        {
            rayHitPoint = rayHit.point;
            RenderLightBeam(hitPos, rayHitPoint);
            if (rayHit.collider.tag == "Mirror")
            {
                rayHit.collider.gameObject.GetComponent<IMirror>().Reflect(reflectDirection, rayHit.point);
            }
            else if (rayHit.collider.tag == "Sensor")
            {
                rayHit.collider.gameObject.GetComponent<ISensor>().Hit();
            }
        }
        else
        {
            RenderLightBeam(hitPos);
        }
    }

    public void Reflect(Vector3 source, Vector3 hitPos, LineRenderer lightBeam)
    {
        hitPoint = hitPos;

        if (Vector3.SignedAngle(source, mirrorTransform.forward, mirrorTransform.forward) < 90)
        {
            reflectDirection = Vector3.Reflect(source, mirrorTransform.forward);
        } else
        {
            reflectDirection = Vector3.Reflect(source, mirrorTransform.forward*-1);
        }

        //Debug.Log(reflectDirection);

        ray = new Ray(hitPos, reflectDirection);
        int linePoints = lightBeam.positionCount;

        if (Physics.Raycast(ray, out rayHit))
        {
            if (rayHitPoint != rayHit.point)
            {
                rayHitPoint = rayHit.point;
                //RenderLightBeam(hitPos, rayHitPoint);

                for (int i = 0; i < linePoints; i++)
                {
                    if (hitPos == lightBeam.GetPosition(i))
                    {
                        //Debug.Log(lineRenderer.positionCount);
                        Vector3[] x = new Vector3[(i + 2)];
                        lightBeam.positionCount = x.Length;
                        lightBeam.GetPositions(x);
                        x[x.Length-1] = rayHitPoint;
                        lightBeam.SetPositions(x);
                        break;
                    }
                }
            }
            if (rayHit.collider.tag == "Mirror")
            {
                rayHit.collider.gameObject.GetComponent<IMirror>().Reflect(reflectDirection, rayHit.point, lightBeam);
            }
            else if (rayHit.collider.tag == "Sensor")
            {
                rayHit.collider.gameObject.GetComponent<ISensor>().Hit();
            }
            
        }
        else
        {
            for (int i = 0; i < linePoints; i++)
            {
                if (hitPos == lightBeam.GetPosition(i))
                {
                    Vector3[] x = new Vector3[(i + 2)];
                    lightBeam.positionCount = x.Length;
                    lightBeam.GetPositions(x);
                    x[x.Length - 1] = mirrorTransform.position + reflectDirection * 3;
                    lightBeam.SetPositions(x);
                    break;
                }
            }
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
        ray = new Ray(mirrorTransform.position, mirrorTransform.forward);
        lineRenderer = gameObject.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
