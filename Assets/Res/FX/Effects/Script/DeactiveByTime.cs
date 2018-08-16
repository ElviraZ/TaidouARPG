using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactiveByTime : MonoBehaviour {

    float deactiveTime = 1f;
     float timer = 0f;
 

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.activeSelf)
        {
            timer += Time.deltaTime;
            if (timer>=deactiveTime)
            {
                timer = 0;
                this.gameObject.SetActive(false);
            }

        }
    }
}
