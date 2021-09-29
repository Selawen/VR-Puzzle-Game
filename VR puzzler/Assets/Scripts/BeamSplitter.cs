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
        lineRenderer.colorGradient = lightBeam.colorGradient;

        //Debug.Log(Vector3.SignedAngle(source, diagonal, diagonal));
        if (Vector3.SignedAngle(source, diagonal, diagonal) <= 90)
        {
            //Debug.Log(diagonal);
            reflectDirection = Vector3.Reflect(source, diagonal);
            //Debug.DrawRay(mirrorTransform.position, reflectDirection, Color.blue);
            //reflectDirection = Vector3.Reflect(reflectDirection, mirrorTransform.forward);
            //reflectDirection = Vector3.Reflect(source, diagonal*-1);
            //reflectDirection = Vector3.Lerp(source, diagonal, 1.5f);
        }
        else
        {
            reflectDirection = Vector3.Reflect(source, diagonal * -1);
        }

        //Debug.DrawRay(mirrorTransform.position, reflectDirection, Color.red);

        //Debug.Log(reflectDirection);

        StartCoroutine(CastRay(lightBeam, reflectDirection, hitPos, rayHitPoint));
        StartCoroutine(Passthrough(source));


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
            
            if (rayHit.collider.CompareTag("Mirror"))
            {
                rayHit.collider.gameObject.GetComponent<IMirror>().Reflect(reflectDirection, rayHit.point, lightBeam);
            }
            else if (rayHit.collider.CompareTag("Sensor"))
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
        diagonal = Vector3.Lerp(forward, mirrorTransform.right, 0.5f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        forward = mirrorTransform.forward;
        diagonal = Vector3.Slerp(forward, mirrorTransform.right, 0.5f);
        //StopBeamRender();
    }

    IEnumerator Passthrough(Vector3 source)
    {
        yield return new WaitForFixedUpdate();

        //Debug.Log("passthrough");
        ray = new Ray(hitPoint, source);

        LayerMask mask = LayerMask.GetMask(new string[2] {"Ignore Raycast", "Ignore Beamsplitter" });
        mask =~ mask;

        if (Physics.Raycast(ray, out rayHit,100, mask))
        {
            Debug.Log("Passthrough hit: " + rayHit.collider.gameObject.name);
            Vector3[] positions = { hitPoint, rayHit.point };
            lineRenderer.SetPositions(positions);

            if (rayHit.collider.CompareTag("Mirror"))
            {
                rayHit.collider.gameObject.GetComponent<IMirror>().Reflect(source, rayHit.point, lineRenderer);
            }
            else if (rayHit.collider.CompareTag("Sensor"))
            {
                rayHit.collider.gameObject.GetComponent<ISensor>().Hit(lineRenderer.startColor);
            }

        }
        else
        {
            Debug.Log("passthrough didn't hit");
            StopBeamRender();
        }
    }

}
