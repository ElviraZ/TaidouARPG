using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class ObjectPool : SingletonMono<ObjectPool>
{
    [HideInInspector]
    public string ResourceDir = "Prefabs/UIPrefabs/";

    Dictionary<string, SubPool> m_pools = new Dictionary<string, SubPool>();

    //取对象
    public GameObject Spawn(ResourcesType type, string name)
    {
        
        if (!m_pools.ContainsKey(name))
            RegisterNew(type,name);
        SubPool pool = m_pools[name];
        return pool.Spawn();
    }

    //回收对象
    public void Unspawn(GameObject go)
    {
        SubPool pool = null;

        foreach (SubPool p in m_pools.Values)
        {
            if (p.Contains(go))
            {
                pool = p;
                break;
            }
        }

        pool.Unspawn(go);
    }

    //回收所有对象
    public void UnspawnAll()
    {
        foreach (SubPool p in m_pools.Values)
            p.UnspawnAll();
    }

    //创建新子池子
    void RegisterNew(ResourcesType  type,string name)
    {
        //预设路径
        string path = "";
        switch (type)
        {
            case ResourcesType.UIPrefabs:
                path = "Prefabs/UIPrefabs/" + name;
                break;
            case ResourcesType.Role:
                path = "Prefabs/RolePrefabs/" + name;
                break;
            case ResourcesType.Effect:
                path = "Prefabs/EffectPrefabs/" + name;
                break;
            default:
                break;
        }
        //加载预设
        GameObject prefab = Resources.Load<GameObject>(path);

        //创建子对象池
        SubPool pool = new SubPool(transform, prefab);
        m_pools.Add(pool.Name, pool);
    }
}