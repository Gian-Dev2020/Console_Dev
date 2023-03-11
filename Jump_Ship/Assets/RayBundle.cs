using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class myRays
{
    public Vector3 Origin;
    public Vector3 Direction;
}
public class RayBundle : MonoBehaviour
{
    [SerializeField] LayerMask hitmask;
    [SerializeField] float sightDistance = 10f;
    [SerializeField] float numRays = 10;
    [SerializeField] float totalAngle = 90;
    List<myRays> Rays = new List<myRays>();
   // List<RaycastHit> info = new List<RaycastHit>();

    [SerializeField] bool RayBundleActive = true;


    Vector3 startPosition;
    Vector3 direction;
    RaycastHit info = new RaycastHit();

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

        for (int i = 0; i < numRays; i++)
        {
            Rays.Add(new myRays());

        }
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

        float gapDegress = totalAngle / (numRays - 1);
        // make the rays
        for(int i = 0;i<numRays; i++)
        {
            Rays[i].Origin = this.transform.position + Vector3.up;
            Rays[i].Direction = this.transform.position + GetVectorFromAngle(this.transform.eulerAngles.y + ((totalAngle/2) - (gapDegress*i)));
        }

        // raycast
        for (int i = 0; i < numRays; i++)
        {
            if (Physics.Raycast(new Ray(Rays[i].Origin, Rays[i].Direction),out info, sightDistance, hitmask, QueryTriggerInteraction.Ignore))
            {
                Debug.Log("hit");
                if (info.collider.gameObject.CompareTag("Player"))
                {
                    Debug.Log("I can see you BITCH!!!");
                }
            }
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

        if (Rays.Count >1)
        {
            for (int i = 0; i < numRays; i++)
            {
                Gizmos.DrawLine(Rays[i].Origin, Rays[i].Origin + (Rays[i].Direction * sightDistance));
            }
        }
        
    }
}
