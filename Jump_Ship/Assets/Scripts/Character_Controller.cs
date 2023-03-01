using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Controller : MonoBehaviour
{
    CharacterController controller;
    float rotation_X = 0f;
    float rotation_Y = 0f;
    float sprint_speed = 10f;
    float walk_speed = 5f;
    float turn_velocity;
    Vector3 fall;

    [SerializeField] float turning_time_smoothing;
    [SerializeField] float speed;
    [SerializeField] float gravtity;
    [SerializeField] Transform camera;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        speed = walk_speed;

    }

    // Update is called once per frame
    void Update()
    {

        Movement();
    }

    void Movement()
    {
        Sprinting();
        Walking();
    }

    void Walking()
    {

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {

            float target_angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + camera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, target_angle, ref turn_velocity, turning_time_smoothing);
            Vector3 move_direction = Quaternion.Euler(0f, target_angle, 0f) * Vector3.forward;

            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            controller.Move(move_direction.normalized * speed * Time.deltaTime);
        }

        // Adding gravity
        fall.y += gravtity * Time.deltaTime;
        controller.Move(fall * Time.deltaTime);
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

    void Crouching()
    {
        // Add crouching
    }
}
