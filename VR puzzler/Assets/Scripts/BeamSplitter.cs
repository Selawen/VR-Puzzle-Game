using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamSplitter : Mirror, IMirror
{
    Vector3 diagonal;
    Vector3 forward;


    public new void Reflect(Vector3 source, Vector3 hitPos, LineRenderer lightBeam)
    {
        hitPoint = hitPos;
        Debug.DrawRay(mirrorTransform.position, diagonal, Color.yellow);

        Debug.Log(Vector3.SignedAngle(source, forward, diagonal));
        if (Vector3.SignedAngle(source, diagonal, diagonal) < 90)
        {
            reflectDirection = Vector3.Reflect(source, mirrorTransform.position + diagonal);
            //reflectDirection = Vector3.Lerp(source, diagonal, 1.5f);
        }
        else
        {
            reflectDirection = Vector3.Reflect(source, diagonal * -1);
        }
        Debug.DrawRay(mirrorTransform.position, reflectDirection, Color.red);

        //Debug.Log(reflectDirection);
        /*
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
                        x[x.Length - 1] = rayHitPoint;
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
                rayHit.collider.gameObject.GetComponent<ISensor>().Hit(lightBeam.startColor);
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
        }*/
    }

    // Start is called before the first frame update
    void Awake()
    {
        forward = mirrorTransform.forward;
        diagonal = Vector3.Lerp(mirrorTransform.forward, mirrorTransform.right, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        forward = mirrorTransform.forward;
        diagonal = Vector3.Lerp(mirrorTransform.forward, mirrorTransform.right, 0.5f);
        StopBeamRender();
    }
}
