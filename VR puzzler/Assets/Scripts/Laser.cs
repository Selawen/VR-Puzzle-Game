using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private Transform laserTransform;
    private Ray ray;
    private RaycastHit rayHit;

    private LineRenderer lineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        laserTransform = gameObject.GetComponent<Transform>();
        ray = new Ray(laserTransform.position, laserTransform.forward);
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        RenderLightBeam();
    }

    private void OnDrawGizmos()
    {
           //Gizmos.DrawLine(laserTransform.position, laserTransform.position+laserTransform.forward*3);
    }
    // Update is called once per frame
    void Update()
    {
        ShootLaser();   
    }

    private void ShootLaser()
    {
        if (Physics.Raycast(ray, out rayHit))
        {
            if (rayHit.collider.tag == "Mirror")
            {
                rayHit.collider.gameObject.GetComponent<IMirror>().Reflect(laserTransform.forward, rayHit.point);
            }
        }
    }

    void RenderLightBeam()
    {
        Vector3[] positions = { laserTransform.position, laserTransform.position + laserTransform.forward * 3 };
        lineRenderer.SetPositions(positions);
    }
}
