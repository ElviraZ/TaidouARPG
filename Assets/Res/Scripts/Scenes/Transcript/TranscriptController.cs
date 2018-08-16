
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranscriptController : SingletonMono<TranscriptController>
{
    [HideInInspector]
 public   PlayerAnimation playerAnimation;


    public List<GameObject> enemyList = new List<GameObject>();
    public override void Awake()
    {
        base.Awake();
        playerAnimation = GameObject.FindGameObjectWithTag(Tags.Player).GetComponent<PlayerAnimation>();
    }

    internal void RemoveEnemy(GameObject gameObject)
    {
        enemyList.Remove(gameObject);
    }
    internal void AddEnemy(GameObject gameObject)
    {
        if (    enemyList.Contains(gameObject)==false)
        {
            enemyList.Add(gameObject);

        }
    }
    internal int GetEnemyCount( )
    {

        return enemyList.Count;

       
    }
}
