using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Controller : MonoBehaviour
{
    CharacterController controller;
    float rotation_X = 0f;
    float rotation_Y = 0f;

    [SerializeField] float speed;
    [SerializeField] float sensitivity;

    Rigidbody rb;
    Vector2 turn;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();

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
}
