using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryByTime : MonoBehaviour {


    public bool isAutoDestory = true;

    public float destoryTime = 0.5f;
	// Use this for initialization
	void Start () {
        if (isAutoDestory)
        {
            Destroy(this.gameObject, destoryTime);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
