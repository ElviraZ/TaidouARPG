using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 抽象UI 的基类
/// </summary>
public class UIBase : MonoBehaviour
{

    public AnimationCurve UIAnimationCurve = new AnimationCurve(new Keyframe(0f, 0f, 0f, 1f), new Keyframe(1f, 1f, 1f, 0f));


    /// <summary>
    /// 当前窗口类型
    /// </summary>
    [HideInInspector]
    public WindowUIType curretnUIType;

    /// <summary>
    /// 下一个将要打开的窗口
    /// </summary>
    protected WindowUIType nextOpenWindow = WindowUIType.None;
    /// <summary>
    /// 打开方式
    /// </summary>
    [SerializeField]
    public WindowShowStyle windowShowStyle = WindowShowStyle.Normal;

    /// <summary>
    /// 动画的持续时间
    /// </summary>
    [SerializeField]
    public float duration = 0.2f;

    public UIButton[] btnArrays;

    public virtual void Awake()
    {
    
    }



    public virtual void Start()
    {
        btnArrays = GetComponentsInChildren<UIButton>(true);
        foreach (UIButton item in btnArrays)
        {
            UIEventListener.Get(item.gameObject).onClick = OnBtnClick;
        }
        OnStart();
    }
    public virtual void OnBtnClick(GameObject go)
    {

    }

    public virtual void OnStart()
    {


    }

    private void OnDestroy()
    {
      BeforeOnDestroy();
    }




    /// <summary>
    /// 在销毁之前执行
    /// </summary>
    public virtual void BeforeOnDestroy()
    {
    
        if (nextOpenWindow == WindowUIType.None)
        {
            return;
        }
        if (nextOpenWindow == WindowUIType.Hide)
        {
        
            WindowUIMgr.Instance.CloseWindow(nextOpenWindow);
            return;
        }
        WindowUIMgr.Instance.OpenWindow(nextOpenWindow,this.transform.parent);
    }

    /// <summary>
    /// 关闭窗口
    /// </summary>
    protected  void Close()
    {
        WindowUIMgr.Instance.CloseWindow(curretnUIType);

    }

}
