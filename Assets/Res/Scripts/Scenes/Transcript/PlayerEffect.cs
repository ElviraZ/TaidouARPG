using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffect : MonoBehaviour
{


    public Renderer[] rendererArray;
    public float lifeTime = 0.2f;


    private void Start()
    {
        rendererArray = GetComponentsInChildren<Renderer>();
        foreach (var item in rendererArray)
        {
            item.enabled = false;
        }
    }



    public void ShowEffect()
    {
        StopAllCoroutines();
        foreach (var item in rendererArray)
        {
            item.enabled = true;
        }
        StartCoroutine("Hide");

    }

  IEnumerator  Hide()
    {
        yield return new WaitForSeconds(lifeTime);
        foreach (var item in rendererArray)
        {
            item.enabled = false;
        }
    }
}
