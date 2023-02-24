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
    private int currentPathPoint = 0;

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
}
