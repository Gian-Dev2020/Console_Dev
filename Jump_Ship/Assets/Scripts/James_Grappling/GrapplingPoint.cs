using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GrapplingPoint : MonoBehaviour
{
    // Controls loction where the player can grapple from
    [SerializeField] private Vector3 StartPos = new Vector3(0, 0, 0);
    [SerializeField] private float StartRadius = 1;
    private SphereCollider sphereCollider;
    // The grappling point location
    private Vector3 EndPos = new Vector3(0, 0, 0);

    private LineRenderer lr;

    // other vars
    [SerializeField] private float GrapplingAcceloration = 0.1f;
    [SerializeField] private float curretGrapplingSpeed = 0;
    [SerializeField] private float MaxGrapplingSpeed = 5;
    [SerializeField] private float rotationSpeed = 10;
    [SerializeField] private bool inGrappleRange = false;
    [SerializeField] private bool currentlyGrappling = false;
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject RopeStartPoint;



    private void Awake()
    {
        sphereCollider = gameObject.GetComponent<SphereCollider>();
        lr = gameObject.GetComponent<LineRenderer>();
        EndPos = gameObject.transform.position;
        inGrappleRange = false;
        currentlyGrappling = false;

    }
    private void Start()
    {
       // sphereCollider.center = StartPos;
        //sphereCollider.radius = StartRadius;
    }
    private void Update()
    {
        // updates the collider to match the position set to it
        //sphereCollider.center = StartPos;
       // sphereCollider.radius = StartRadius;


        if (inGrappleRange && !currentlyGrappling && Input.GetKeyDown(KeyCode.E))
        {
            currentlyGrappling = true;
        }
        if (currentlyGrappling)
        {
            Grappling();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inGrappleRange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inGrappleRange = false;
        }
    }

    private void Grappling()
    {
        // disable player movemnt controls

        // rotate player to fcae grapple point

        // animation to grapple

        // rope/grapple shoots into the grapple point
        lr.enabled = true;
        lr.SetPosition(0, RopeStartPoint.transform.position);
        lr.SetPosition(1, EndPos);

        // move the player to the grapple point whilst decreasign size of rope
        // this shoudl be smooth and fast
        // try and also have some sort of acceloration 

        Vector3 direction = new Vector3(EndPos.x, EndPos.y + 1, EndPos.z) - Player.transform.position;
        //direction.y = 0;

        // turns to face grappling point
        //Player.transform.rotation = Quaternion.Slerp(Player.transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);

        Player.transform.rotation = Quaternion.Slerp(Player.transform.rotation, Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z)), rotationSpeed * Time.deltaTime);

        if (direction.magnitude > 0.1)
        {
            
            if (curretGrapplingSpeed < MaxGrapplingSpeed)
            {
                curretGrapplingSpeed += GrapplingAcceloration;
            }

            Vector3 moveVector = direction.normalized * curretGrapplingSpeed * Time.deltaTime;

            //Vector3 moveVector = (Player.transform.forward + Player.transform.up) * curretGrapplingSpeed * Time.deltaTime;
            Player.transform.position += moveVector;
        }
        else
        {
            // arrived at destination
            lr.enabled = false;
        }


        // the player to haev animation or effect to land above grapplign point
    }


}


