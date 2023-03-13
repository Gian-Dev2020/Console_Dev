using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    Vector3 playerPos;
    Vector3 teleportPos;

    int teleportDist;

    //-----TEST-----------
    //public GameObject cube;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        teleportDist = 5;
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = player.transform.position;
        teleportPos = player.transform.position + (transform.forward * teleportDist);

        if (Input.GetKeyDown(KeyCode.T))
        {
           // player.GetComponent<CharacterController>().enabled = false;
            player.transform.position = teleportPos;
            Debug.Log("Player position is: " + playerPos);
            //player.GetComponent<CharacterController>().enabled = true;

        }
    }
}
