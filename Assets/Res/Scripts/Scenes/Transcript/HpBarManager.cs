using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBarManager : SingletonMono<HpBarManager>
{

    public GameObject hpBarPrefab;

    public GameObject hudTextPrefab;

    /// <summary>
    /// 返回一个Hpbar，target参数是跟随的目标
    /// </summary>
    /// <param name="target"></param>
    /// <returns></returns>
    public GameObject GetHpBar(Transform target)
    {
        GameObject go = NGUITools.AddChild(this.gameObject, hpBarPrefab);
        go.GetComponent<UIFollowTarget>().target = target;
        return go;
    }

    /// <summary>
    /// 返回一个HudText，target参数是跟随的目标
    /// </summary>
    /// <param name="target"></param>
    /// <returns></returns>
    public GameObject GetHudText(Transform target)
    {
        GameObject go = NGUITools.AddChild(this.gameObject, hudTextPrefab);
        go.GetComponent<UIFollowTarget>().target = target;
        return go;
    }
}
