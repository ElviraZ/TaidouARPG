/*******
* Copyright (C)2018    Administrator 
* 创建人:              Administrator  
* 创建时间:            2018/6/14 星期四 14:09:06
 *
 *
 * 单例基类
****************************/
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
/// <summary>
/// 单例基类，不是Mono的单例
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class Singleton<T>: IDisposable where T : new()
{
    private static T m_instance  ;

    public static T Instance
    {

        get {
            if (m_instance==null)
            {
                m_instance = new T();
            }
            return m_instance; }
    }

    public  virtual void Dispose()
    {
        
    }
}
