using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision_Detection : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Target")
        {
            Destroy(this.gameObject);
            other.gameObject.SetActive(false);
            return;
        }
    }
}
