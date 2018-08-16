using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PlayerVilliageMove : MonoBehaviour
{
    private NavMeshAgent agent;

    float velocity = 15;
    Rigidbody m_rigibody;
	// Use this for initialization
	void Start () {
        m_rigibody = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float vely = m_rigibody.velocity.y;
        m_rigibody.velocity = new UnityEngine.Vector3(-h * velocity, vely, -v * velocity);

        if (Mathf.Abs(h)>0.01f||Mathf.Abs(v)>0.01f)
        {
            transform.rotation=Quaternion.LookRotation(new Vector3(-h,0,-v));
            this.GetComponent<PlayerAutoMove>().StopAgent();

        }
        else
        {
            if (agent.enabled==false)
            {
                m_rigibody.velocity = Vector3.zero;
            }
        }
        if (agent.enabled)
        {
            transform.rotation = Quaternion.LookRotation(agent.velocity);
        }

    }
}
