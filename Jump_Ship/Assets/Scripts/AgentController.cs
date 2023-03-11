using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentController : MonoBehaviour
{

    [SerializeField] AgentType agentType;
    private NavMeshAgent agent;
    [SerializeField] bool walking;
    // roaming agent
    [SerializeField] bool usePathPoints;
    [SerializeField] List<GameObject> pathPoints;
    [SerializeField] float waitTime = 2;

    [SerializeField] LayerMask hitmask;
    [SerializeField] float sightDistance = 10f;
    [SerializeField] float sphereCastRadius = 2f;
    [SerializeField] Invisibility Player;
    private int currentPathPoint = 0;
    private RaycastHit info = new RaycastHit();

    public enum AgentType
    {
        BuffDaddy,
        Robot,
        Guard1
    }
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void Start()
    {
        if (usePathPoints)
        {
            walking = true;
            agent.SetDestination(pathPoints[currentPathPoint].transform.position);
        }
    }
    private void Update()
    {
     if (usePathPoints && walking)
        {
            float dist = Mathf.Abs(Vector3.Distance(pathPoints[currentPathPoint].transform.position, this.transform.position));
            // if arrived at pathpoint wait then call next pathpoint
            if (dist < 0.1)
            {
                walking = false;
                Invoke("UpdatePathPoint", waitTime);
            }
        }

        Scan();
    }

    private void Scan()
    {        
        if(Physics.SphereCast(new Ray(this.transform.position, this.transform.forward), sphereCastRadius, out info, sightDistance, hitmask, QueryTriggerInteraction.Ignore))
        {
            if (Invisibility.detectable)
            {
                Debug.Log("Player has been seen by me:  " + agentType + "  " + this.gameObject.name);
            }            
        }

        
    }

    void UpdatePathPoint()
    {
        walking = true;
        currentPathPoint++;
        if (currentPathPoint >= pathPoints.Count)
        {
            currentPathPoint = 0;
        }
        
        agent.SetDestination(pathPoints[currentPathPoint].transform.position);
    }





    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;

        Gizmos.matrix *= Matrix4x4.TRS(transform.position, transform.rotation, Vector3.one);
        float length = sightDistance;

        Gizmos.DrawWireSphere(Vector3.zero, sphereCastRadius);

        Gizmos.DrawWireSphere(Vector3.zero + Vector3.forward * length, sphereCastRadius);
        Gizmos.DrawLine(Vector3.up * sphereCastRadius, Vector3.up * sphereCastRadius + Vector3.forward * length);
        Gizmos.DrawLine(Vector3.down * sphereCastRadius, Vector3.down * sphereCastRadius + Vector3.forward * length);
        Gizmos.DrawLine(Vector3.left * sphereCastRadius, Vector3.left * sphereCastRadius + Vector3.forward * length);
        Gizmos.DrawLine(Vector3.right * sphereCastRadius, Vector3.right * sphereCastRadius + Vector3.forward * length);
    }
}

