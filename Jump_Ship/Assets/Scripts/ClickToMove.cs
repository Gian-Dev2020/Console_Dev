
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickToMove : MonoBehaviour
{

    [SerializeField] NavMeshAgent agent;

    
    
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Ray movePosition = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(movePosition,out var hitInfo))
            {
                agent.SetDestination(hitInfo.point);
            }

        }
    }
}
