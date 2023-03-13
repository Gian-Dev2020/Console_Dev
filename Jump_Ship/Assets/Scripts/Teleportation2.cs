using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation2 : MonoBehaviour
{
    [SerializeField] private Color hitColour = Color.red;
    [SerializeField] private Color hitColourAll = Color.yellow;
    [SerializeField] private bool multiple;

    public RaycastHit objectHit = new RaycastHit();

    public LayerMask hitMask;
    public float teleportDist = 5.0f;
    public bool Hit { get; private set; }

    Transform objectTransform;
    
    // Start is called before the first frame update
    void Start()
    {
        objectTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastTP();
    }

    public bool RaycastTP()
    {
        Hit = false;

        Vector3 origin = objectTransform.position; //TO D0: Change origin point to camera
        Vector3 direction = objectTransform.forward;
        

        //Debug.DrawRay(origin, direction * teleportDist, Color.green);
        //Ray ray = new Ray(origin, direction);

        if (Physics.Linecast(origin, origin + direction * teleportDist, out objectHit, hitMask, QueryTriggerInteraction.Ignore)) //teleportDist is the actual length of the ray
        {
            objectHit.collider.GetComponent<Renderer>().material.color = hitColour;
            Hit = true;
            
            return true;
        }

        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        if (objectTransform == null)
        {
            objectTransform = GetComponent<Transform>();
        }

        RaycastTP();

        Gizmos.matrix *= Matrix4x4.TRS(objectTransform.position, objectTransform.rotation, Vector3.one);
        float newDistance = teleportDist;

        if (Hit) newDistance = Vector3.Distance(this.transform.position, objectHit.point);

        Gizmos.DrawLine(Vector3.zero, Vector3.forward * newDistance);
    }

    //private void MultipleRaycast()
    //{
    //    Vector3 origin = transform.position;
    //    Vector3 direction = transform.forward;

    //    Debug.DrawRay(origin, direction * teleportDist, Color.green);
    //    Ray ray = new Ray(origin, direction);

    //    var multipleHits = Physics.RaycastAll(ray, teleportDist);
    //    foreach (var raycastHit in multipleHits)
    //    {
    //        raycastHit.collider.GetComponent<Renderer>().material.color = hitColourAll;
    //    }
    //}
}
