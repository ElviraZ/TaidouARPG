using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 窗口UI 管理器
/// </summary>
public class WindowUIMgr : Singleton<WindowUIMgr>
{
    private Dictionary<WindowUIType, UIBase> dicWindow = new Dictionary<WindowUIType, UIBase>();


    public int OpenWindowCount
    {
        get { return dicWindow.Count; }

    }

    #region   打开窗口  LoadWindow

    /// <summary>
    /// 打开窗口
    /// </summary>
    /// <param name="windowUIType">窗口类型</param>

    /// <returns></returns>
    public GameObject OpenWindow(WindowUIType windowUIType,Transform transParent=null)
    {
        if (windowUIType == WindowUIType.None)
        {
            return null;
        }
        GameObject obj = null;

        UIBase windowBase = null;
        if (!dicWindow.ContainsKey(windowUIType))
        {
            //前提：枚举的名字必须和预制件的名字一致
            obj = ResourcesMgr.Instance.Load(ResourcesType.UIPrefabs, string.Format("{0}", windowUIType.ToString()), true);
            if (obj == null)
            {
                return null;
            }
             windowBase = obj.GetComponent<UIBase>();
            if (windowBase == null)
            {
                return null;
            }
            windowBase.curretnUIType = windowUIType;
            dicWindow.Add(windowUIType, windowBase);
            obj.transform.parent = transParent;
            obj.transform.localPosition = Vector3.one;
            obj.transform.localScale = Vector3.one;
            NGUITools.SetActive(obj, false);
        }
        else
        {
            obj = dicWindow[windowUIType].gameObject;
            windowBase = obj.GetComponent<UIBase>();
        }

        StartShowWindow(windowBase, true);

        return obj;
    }


    #endregion
    #region       开始打开窗口   StartShowWindow
    #region     关闭窗口
    public void CloseWindow(WindowUIType windowUIType)
    {
        if (dicWindow.ContainsKey(windowUIType))
        {
            StartShowWindow(dicWindow[windowUIType], false);

        }

    }
    #endregion
    /// <summary>
    /// 开始打开窗口
    /// </summary>
    /// <param name="windowBase"></param>
    /// <param name="isOpen"></param>
    private void StartShowWindow(UIBase windowBase, bool isOpen)
    {
        switch (windowBase.windowShowStyle)
        {
            case WindowShowStyle.Normal:
                ShowNormal(windowBase, isOpen);
                break;
            case WindowShowStyle.CenterToBig:
                ShowCenterToBig(windowBase, isOpen);
                break;
            case WindowShowStyle.FromTop:
                ShowFromDir(windowBase, 0, isOpen);
                break;
            case WindowShowStyle.FromDown:
                ShowFromDir(windowBase, 1, isOpen);
                break;
            case WindowShowStyle.FromLeft:
                ShowFromDir(windowBase, 2, isOpen);
                break;
            case WindowShowStyle.FromRight:
                ShowFromDir(windowBase, 3, isOpen);
                break;
            default:

                break;
        }
    }


    #endregion

    #region     窗口打开效果
    private void ShowNormal(UIBase windowBase, bool isOpen)
    {
        if (isOpen)
        {
            NGUITools.SetActive(windowBase.gameObject, isOpen);
        }
        else
        {
            DestroyWindow(windowBase);

        }
    }
    /// <summary>
    /// 从中间变大
    /// </summary>
    /// <param name="go"></param>
    /// <param name="isOpen"></param>
    private void ShowCenterToBig(UIBase windowBase, bool isOpen)
    {
        TweenScale ts = windowBase.gameObject.GetOrCreateComponent<TweenScale>();

        ts.from = Vector3.zero;
        ts.to = Vector3.one;
        ts.duration = windowBase.duration;
        ts.animationCurve = windowBase.UIAnimationCurve;
        ts.SetOnFinished(() =>
        {
            if (!isOpen)
            {
                DestroyWindow(windowBase);
            }
        });
        NGUITools.SetActive(windowBase.gameObject, true);
        if (!isOpen)
        {
            ts.Play(isOpen);
        }
    }
    /// <summary>
    /// 从不同的方向进入的效果
    /// dirType：
    /// 0-FromTop
    /// 1-FromDown
    /// 2-FromLeft
    /// 3-FromRight
    /// </summary>
    /// <param name="windowBase"></param>
    /// <param name="dirType"></param>
    /// <param name="isOpen"></param>
    private void ShowFromDir(UIBase windowBase, int dirType, bool isOpen)
    {
        TweenPosition tp = windowBase.gameObject.GetOrCreateComponent<TweenPosition>();
        Vector3 from = Vector3.zero;
        switch (dirType)
        {
            case 0:
                from.y = 1500f;
                break;
            case 1:
                from.y = -1500f;
                break;
            case 2:
                from.x= -2000f;
                break;
            case 3:
                from.x = 2000;
                break;

            default:
                break;
        }
        tp.from = from;
        tp.to = Vector3.zero;
        tp.duration = windowBase.duration;
        tp.animationCurve = windowBase.UIAnimationCurve;
        tp.SetOnFinished(() =>
        {
            if (!isOpen)
            {
                DestroyWindow(windowBase);
            }
        });
        NGUITools.SetActive(windowBase.gameObject, true);
        if (!isOpen)
        {
            tp.Play(isOpen);
        }
    }

    #endregion

    /// <summary>
    /// 销毁窗口
    /// </summary>
    /// <param name="go"></param>
    private void DestroyWindow(UIBase windowBase)
    {
        dicWindow.Remove(windowBase.curretnUIType);
        //Game.Instance.ObjectPool.Unspawn(windowBase.gameObject);
        UnityEngine.Object.Destroy(windowBase.gameObject);
        //windowBase.Hide();
    }
}
