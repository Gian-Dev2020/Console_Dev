using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayBundle : MonoBehaviour
{
    [SerializeField] LayerMask hitmask;
    [SerializeField] float sightDistance = 10f;
    [SerializeField] float numRays = 10;
    List<Ray> Rays = new List<Ray>();
   // List<RaycastHit> info = new List<RaycastHit>();

    [SerializeField] bool RayBundleActive = true;


    Vector3 startPosition;
    Vector3 direction;
    private RaycastHit info = new RaycastHit();

    //private void Awake()
    //{
    //    for(int i = 0; i< numRays; i++)
    //    {
    //        Rays.Add(new Ray(transform.position, new Vector3(1,0,0)));
    //        info.Add(new RaycastHit());
    //    }
    //}

    private void Start()
    {
        startPosition = this.transform.position + Vector3.up;
        direction = new Vector3(0, 0, 1).normalized;
    }



    private void Update()
    {
        if (RayBundleActive)
        {
            Scan();
        }
    }

    private void Scan()
    {
        startPosition = this.transform.position + Vector3.up;
        direction = this.transform.position + GetVectorFromAngle(this.transform.eulerAngles.y + 45);


        Debug.Log(this.transform.eulerAngles.y);
        if (Physics.Raycast(new Ray(startPosition, direction), out info, sightDistance, hitmask, QueryTriggerInteraction.Ignore))
        {
            Debug.Log("hit");
        }            
    }


    static Vector3 GetVectorFromAngle(float angle)
    {
        // angle = 0->360
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3( Mathf.Sin(angleRad),0, Mathf.Cos(angleRad));
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Gizmos.matrix *= Matrix4x4.TRS(transform.position, transform.rotation, Vector3.one);
        
        //Gizmos.DrawRay(new Ray(startPosition, direction * sightDistance));
        Gizmos.DrawLine(startPosition, startPosition + (direction * sightDistance));
    }
}
