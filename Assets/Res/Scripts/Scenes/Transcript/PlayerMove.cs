using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float velocity = 10;
    Rigidbody m_rigibody;
    Animator anim;
    void Start ()
    {
        m_rigibody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float vely = m_rigibody.velocity.y;

        if (Mathf.Abs(h) > 0.01f || Mathf.Abs(v) > 0.01f)
        {

        m_rigibody.velocity = new UnityEngine.Vector3(h * velocity, vely, v * velocity);
            transform.rotation = Quaternion.LookRotation(new Vector3(h, 0, v));
          

        }
        else
        {
            m_rigibody.velocity = new UnityEngine.Vector3(0, vely, 0);
        }
    }
}
