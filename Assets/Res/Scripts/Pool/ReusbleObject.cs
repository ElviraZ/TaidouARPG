/*******
* Copyright (C)2018    Administrator 
* 创建人:              Administrator  
* 创建时间:            2018/6/14 星期四 14:06:47    
****************************/
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public abstract class ReusbleObject : MonoBehaviour, IReusable
{
    public abstract void OnSpawn();

    public abstract void OnUnspawn();
}
