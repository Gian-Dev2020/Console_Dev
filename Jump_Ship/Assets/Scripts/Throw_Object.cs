using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Throw_Object : MonoBehaviour
{

    public Transform cam;
    public Transform attack_point;
    public GameObject object_to_throw;

    public int total_throws;
    public float throw_cooldown;

    public KeyCode throw_Key = KeyCode.Mouse0;
    public float throw_force;
    public float throw_up_force;

    bool ready_to_throw;

    // Start is called before the first frame update
    void Start()
    {
        ready_to_throw = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(throw_Key) && ready_to_throw && total_throws > 0)
        {
            Throw();
        }
    }

    void Throw()
    {
        ready_to_throw = false;

        //Instantiate the object to throw
        GameObject projectile = Instantiate(object_to_throw, attack_point.position, cam.rotation);

        //Get Rigidbody component
        Rigidbody projectile_rb = projectile.GetComponent<Rigidbody>();

        //Add force
        Vector3 force_to_add = cam.transform.forward * throw_force + transform.up * throw_up_force;

        projectile_rb.AddForce(force_to_add, ForceMode.Impulse);

        total_throws--;

        // Cooldown
        Invoke(nameof(ResetThrow), throw_cooldown);
    }

    void ResetThrow()
    {
        ready_to_throw = true;
    }
}
