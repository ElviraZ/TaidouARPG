using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PlayerAutoMove : MonoBehaviour
{
    private NavMeshAgent agent;

    private void Awake()
    {
        agent=GetComponent<NavMeshAgent>();
          
        agent.enabled = false;
    }

	void Update ()
    {
        if (agent.enabled && Vector3.Distance(this.transform.position,agent.destination)<2f)
        {
            agent.isStopped = true;
            agent.enabled = false;
       
        }
   
	}

    public void SetDestination(Vector3  targetPos)
    {
        agent.enabled = true;
        agent.SetDestination(targetPos) ;


    }

    public void StopAgent( )
    {
        if (agent.enabled)
        {
            agent.isStopped = true;
            agent.enabled = false;
        }
      


    }
}
