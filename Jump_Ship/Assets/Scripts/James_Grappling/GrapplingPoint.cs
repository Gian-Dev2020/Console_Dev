using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GrapplingPoint : MonoBehaviour
{
    // Controls loction where the player can grapple from
    [SerializeField] private Vector3 StartPos = new Vector3 (0,0,0);    
    [SerializeField] private float StartRadius = 1;
    private SphereCollider sphereCollider;
    // The grappling point location
    private Vector3 EndPos = new Vector3(0, 0, 0);

    // other vars
    [SerializeField] private float grapplingSpeed = 1;
    [SerializeField] private bool inGrappleRange = false;

    

    private void Awake()
    {
        sphereCollider = gameObject.GetComponent<SphereCollider>();
        EndPos = gameObject.transform.position;
        grapplingSpeed = 1;
        inGrappleRange = false;
    }
    private void Start()
    {
        sphereCollider.center = StartPos;
        sphereCollider.radius = StartRadius;
    }
    private void Update()
    {
        // updates the collider to match the position set to it
        sphereCollider.center = StartPos;
        sphereCollider.radius = StartRadius;
    }

    private void OnTriggerEnter(Collider other)
    { 
        if (other.gameObject.CompareTag("Player"))
        {
            inGrappleRange = true;
        } 
    }
    private void OnTriggerExit (Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inGrappleRange = false;
        }
    }
}


