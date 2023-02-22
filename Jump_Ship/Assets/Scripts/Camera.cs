using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    float rotation_X = 0f;
    float rotation_Y = 0f;

    [SerializeField] float sensitivity = 15f;

   
    // Update is called once per frame
    void Update()
    {
        rotation_X += Input.GetAxis("Mouse Y") * -1 * sensitivity;
        rotation_Y += Input.GetAxis("Mouse X") * sensitivity;
    }
}
