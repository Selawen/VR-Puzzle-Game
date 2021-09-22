using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightSource : MonoBehaviour
{
    private Ray ray;
    private RaycastHit rayHit;

    [SerializeField] private Vector3 originPos;

    private void Start()
    {
        originPos = transform.position;
    }

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("Found " + other.gameObject.name);

        if (other.tag == "Sensor")
        {
            //Debug.Log("Found " + other.gameObject.name);
            //Vector3 direction = transform.forward;
            ray = new Ray(originPos, other.transform.position-originPos);
            //Debug.DrawRay(originPos, (other.transform.position - originPos), Color.yellow);
            if (Physics.Raycast(ray, out rayHit))
            {
                //Debug.DrawRay(originPos, rayHit.point, Color.yellow);
                if (rayHit.collider != other)
                {
                    //Debug.Log("hit " + other.gameObject.name);
                    return;
                }
                else
                {
                    rayHit.collider.gameObject.GetComponent<ISensor>().Hit();
                }
            }
        }
    }
}
