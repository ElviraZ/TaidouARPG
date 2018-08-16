using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{

    public Vector3 offset ;
    public Transform player;

    public float smoothing = 4f;

	void Start ()
    {
        player = GameObject.FindGameObjectWithTag(Tags.Player).transform.Find("Bip01");
	}
    
	void FixedUpdate ()
    {
        //  transform.position = player.position + offset;


        if (player==null)
        {
            return;
        }
        Vector3  targetPos = player.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPos, smoothing * Time.deltaTime);
    }
}
