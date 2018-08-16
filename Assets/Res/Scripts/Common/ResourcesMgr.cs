using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;

public class ResourcesMgr : Singleton<ResourcesMgr>
{

    /// <summary>
    /// 资源类型
    /// </summary>

    private Hashtable prefabTable;
    public ResourcesMgr()
    {
        prefabTable = new Hashtable();
    }
    /// <summary>
    /// 加载并实例化一个资源，cache：是否加入缓存，返回实例化的克隆体
    /// </summary>
    /// <param name="type"></param>
    /// <param name="path"></param>
    /// <param name="cache"></param>
    /// <returns></returns>
    public GameObject Load(ResourcesType type, string path, bool cache = false)
    {

        GameObject obj = null;
        if (prefabTable.Contains(path))
        {
            obj = prefabTable[path] as GameObject;
            //    Debug.Log("缓存加载");
        }
        else
        {
            StringBuilder stringBuilder = new StringBuilder();
            switch (type)
            {
       
                case ResourcesType.UIPrefabs:
                    stringBuilder.Append("Prefabs/UIPrefabs/");
                    break;
                case ResourcesType.Role:
                    stringBuilder.Append("Prefabs/RolePrefabs/");
                    break;
                case ResourcesType.Effect:
                    stringBuilder.Append("Prefabs/EffectPrefabs/");
                    break;
                default:
                    break;
            }

            stringBuilder.Append(path);
            obj = Resources.Load<GameObject>(stringBuilder.ToString()) as GameObject;
           // obj = Game.Instance.ObjectPool.Spawn(stringBuilder.ToString());
            if (cache)
            {
                prefabTable.Add(path, obj);
            }
            // Debug.Log("新加载");
        }
        return GameObject.Instantiate(obj);
    }

    public override void Dispose()
    {
        base.Dispose();
        prefabTable.Clear();
        Resources.UnloadUnusedAssets();
        GC.Collect();
    }

}
