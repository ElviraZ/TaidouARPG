using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
public class EnemyTrigger : MonoBehaviour
{
    [Tooltip("此处的怪物预制件")]
    public GameObject[] enemtPrefabs;
    [Tooltip("此处的怪物出生点")]
    public Transform[] spawnTransform;
    [Tooltip("多少秒之后开始生成怪物")]
    public float time = 0;//多少秒之后开始生成
    [Tooltip("怪物生成的间隔时间")]
    public float repateTime = 2f;//生成的间隔
    [Tooltip("此处的怪物最大数量")]
    public int maxCount = 10;

    private int deadCount;
    public int DeadCount
    {
        get { return deadCount; }
        set {
            deadCount = value;
            if (deadCount>=maxCount)
            {
                Destroy(this.gameObject);
            }
        }
    }
    public bool isCanTrigger = true;
    IEnumerator SpawnEnemy()
    {
      
           yield return new WaitForSeconds(time);
        int randomEnemy = 0;
        int randomPos = 0;
        for (int i = 0; i < maxCount; i++)
        {
             randomEnemy = Random.Range(0, enemtPrefabs.Length );
             randomPos = Random.Range(0, spawnTransform.Length );
            GameObject go = GameObject.Instantiate(enemtPrefabs[randomEnemy], spawnTransform[randomPos].position, Quaternion.identity);
            go.name = enemtPrefabs[randomEnemy].name;
            if (go.name!= "Boss")
            {
                go.GetComponent<EnemyBase>().Init(this);

            }
            yield return new WaitForSeconds(repateTime);
        }
        yield return new WaitForSeconds(repateTime);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == Tags.Player)
        {
            if (isCanTrigger)
            {
                StartCoroutine("SpawnEnemy");
                isCanTrigger = false;
            }
        }

    }
    public void EnemyDead()
    {
        DeadCount++;
        Debug.Log("EnemyDead     ========" + DeadCount);


    }
}
