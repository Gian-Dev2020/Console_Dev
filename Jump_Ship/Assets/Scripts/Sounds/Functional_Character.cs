using GamePlay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI; // For use of Navmesh Agent
public class Functional_Character : MonoBehaviour, IHear
{
    [SerializeField] NavMeshAgent agent = null;

    void Awake()
    {
        // Tries to find a NavMeshAgent on the object being assigned
        if(!TryGetComponent(out agent))
        {
            Debug.LogWarning("No agent found");
        }


    }

    public void RespondToSound(Sound sound)
    {
        if(sound.sound_type == Sound.SoundType.Interesting)
        {
            MoveToward(sound.pos);
        }

        else if(sound.sound_type == Sound.SoundType.Danger) 
        {
            Vector3 dir = (sound.pos - transform.position).normalized;
            MoveToward(transform.position - (dir * 10f));
        }
        Debug.Log("Responding to sound");
    }

    void MoveToward(Vector3 pos)
    {
        agent.SetDestination(pos);
        agent.isStopped = false;
    }
}
