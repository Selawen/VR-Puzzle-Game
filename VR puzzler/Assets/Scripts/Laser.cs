using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    [SerializeField] private Transform laserTransform;
    private Ray ray;
    private RaycastHit rayHit;
    private Vector3 hitPoint;

    private LineRenderer lineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        laserTransform = gameObject.GetComponent<Transform>();
        ray = new Ray(laserTransform.position, laserTransform.forward);
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        //RenderLightBeam();
    }

    private void OnDrawGizmos()
    {
           //Gizmos.DrawLine(laserTransform.position, laserTransform.position+laserTransform.forward*3);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ShootLaser();   
    }

    private void ShootLaser()
    {
        if (Physics.Raycast(ray, out rayHit))
        {
            if (hitPoint != rayHit.point)
            {
                hitPoint = rayHit.point;
                RenderLightBeam();
            }

            if (rayHit.collider.tag == "Mirror")
            {
                rayHit.collider.gameObject.GetComponent<IMirror>().Reflect(laserTransform.forward, rayHit.point, lineRenderer);
            } else if (rayHit.collider.tag == "Sensor")
            {
                rayHit.collider.gameObject.GetComponent<ISensor>().Hit(lineRenderer.startColor);
            }
        }
    }

    void RenderLightBeam()
    {
        Vector3[] positions = { laserTransform.position, hitPoint };
        lineRenderer.SetPosition(0, laserTransform.position);
        lineRenderer.SetPosition(1, hitPoint);
    }
}
