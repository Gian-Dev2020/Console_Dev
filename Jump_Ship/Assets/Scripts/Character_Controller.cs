using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Controller : MonoBehaviour
{
    CharacterController controller;
    float rotation_X = 0f;
    float rotation_Y = 0f;

    [SerializeField] float sensitivity;

    float speed;
    float sprint_speed = 10f;
    float walk_speed = 5f;
    Rigidbody rb;
    Vector2 turn;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        speed = walk_speed;

    }

    // Update is called once per frame
    void Update()
    {
        rotation_Y = Input.GetAxis("Mouse X") * sensitivity;
        rotation_X = Input.GetAxis("Mouse Y") * sensitivity;

        this.transform.Rotate(0f, rotation_Y, 0f, Space.Self);

        Movement();
    }

    void Movement()
    {
        Sprinting();
        Walking();
    }

    void Walking()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * Time.deltaTime * speed;

        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position += -transform.forward * Time.deltaTime * speed;

        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += -transform.right * Time.deltaTime * speed;

        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * Time.deltaTime * speed;

        }
    }

    void Sprinting()
    {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            speed = sprint_speed;
        }

        else if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
        {
            speed = walk_speed;
        }
    }
}
