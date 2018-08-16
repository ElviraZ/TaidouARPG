using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

[RequireComponent(typeof(ObjectPool))]
[RequireComponent(typeof(AudioController))]

public class Game : SingletonMono<Game>
{
    //全局访问功能

    public ObjectPool ObjectPool = null; //对象池
  
    public AudioController Sound = null;//声音控制


    public override void Awake()
    {
        base.Awake();
        //确保Game对象一直存在
        Object.DontDestroyOnLoad(this.gameObject);

        //全局单例赋值
        ObjectPool = GetComponent<ObjectPool>();
        Sound = GetComponent<AudioController>();
    }

}
