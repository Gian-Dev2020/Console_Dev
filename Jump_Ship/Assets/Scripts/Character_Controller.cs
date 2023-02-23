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
    Vector2 turn;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
       
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        controller.Move(move * speed * Time.deltaTime);

        rotation_Y = Input.GetAxis("Mouse X") * sensitivity;
        rotation_X = Input.GetAxis("Mouse Y") * sensitivity;

        this.transform.Rotate(0f, rotation_Y, 0f, Space.World);
       
       
    }
}
