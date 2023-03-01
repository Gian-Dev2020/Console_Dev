using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    //Invisibility invisibility;
    public LayerMask hitMask;
    public enum Type
    {
        Line,
        Raybundle,
        SphereCast,
        BoxCast
    }

    public Type sensorType = Type.Line;
    public float raycastLength = 1.0f;

    [Header("BoxExtent Settings")]
    public Vector2 boxExtents = new Vector2(1.0f, 1.0f);

    [Header("SphereExtent Settings")]
    public float sphereRadius = 1.0f;

    Transform cachedTransform;
    // Start is called before the first frame update
    void Start()
    {
        cachedTransform = GetComponent<Transform>();
        //invisibility = GetComponent<Invisibility>();
    }

    private void Update()
    {
        scan();
    }

    public bool Hit { get; private set; }
    public RaycastHit info = new RaycastHit();

    public bool scan()
    {
        Hit = false;
        Vector3 dir = cachedTransform.forward;

        switch (sensorType)
        {
            case Type.Line:
                if (Physics.Linecast(cachedTransform.position, cachedTransform.position + dir * raycastLength, out info, hitMask, QueryTriggerInteraction.Ignore) && Invisibility.detectable)
                {
                    Hit = true;
                    Debug.Log("Hit");
                    return true;

                }
                break;

            case Type.SphereCast:
                if (Physics.SphereCast(new Ray(cachedTransform.position, dir), sphereRadius, out info, raycastLength, hitMask, QueryTriggerInteraction.Ignore))
                {
                    Hit = true;
                    Debug.Log("Hit");
                    return true;

                }
                break;

            case Type.BoxCast:
                if (Physics.CheckBox(this.transform.position, new Vector3(boxExtents.x, boxExtents.y, raycastLength) / 2.0f, this.transform.rotation, hitMask, QueryTriggerInteraction.Ignore))
                {
                    Hit = true;
                    Debug.Log("Hit");
                    return true;

                }
                break;
        }

        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        if (cachedTransform == null)
        {
            cachedTransform = GetComponent<Transform>();
        }

        scan();

        if (Hit) Gizmos.color = Color.green;

        Gizmos.matrix *= Matrix4x4.TRS(transform.position, transform.rotation, Vector3.one);
        float length = raycastLength;

        switch (sensorType)
        {
            case Type.Line:
                if (Hit) length = Vector3.Distance(this.transform.position, info.point);
                Gizmos.DrawLine(Vector3.zero, Vector3.forward * length);
                Gizmos.color = Color.black;
                Gizmos.DrawCube(Vector3.forward * length, new Vector3(0.02f, 0.02f, 0.02f));
                break;

            case Type.SphereCast:
                Gizmos.DrawWireSphere(Vector3.zero, sphereRadius);
                if (Hit)
                {
                    Vector3 ballCentre = info.point + info.normal * sphereRadius;
                    length = Vector3.Distance(cachedTransform.position, ballCentre);
                }
                break;

            case Type.BoxCast:
                Gizmos.DrawWireCube(Vector3.zero, new Vector3(boxExtents.x, boxExtents.y, length));
                break;
        }
    }
}
