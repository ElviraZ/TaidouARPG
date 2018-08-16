using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVilliageAnimation : MonoBehaviour
{
    Animator anim;
    Rigidbody rigi;
    float velocity = 0.0f;

    void Start ()
    {
        anim = GetComponent<Animator>();
        rigi = GetComponent<Rigidbody>();

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (rigi!=null)
        {
    velocity = rigi.velocity.magnitude;
        }
     
        if (velocity > 0.01f|| (ETCInput.GetAxis("Vertical") != 0 || ETCInput.GetAxis("Horizontal") != 0))
        {
            anim.SetBool("Move", true);
        }
        else
        {
            anim.SetBool("Move", false);
        }

    }
}
