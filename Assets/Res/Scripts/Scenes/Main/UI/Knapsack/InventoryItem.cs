using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// 单个物品的信息
/// </summary>
public class InventoryItem
{
    private Inventory _inventory;
    private int _level;
    private int _count;


    private bool dressed = false;
    public bool Dressed
    {
        get { return dressed; }
        set { dressed = value; }
    }
    public Inventory Inventory
    {
        get { return _inventory; }
        set { _inventory = value; }
    }

    public int Level
    {
        get { return _level; }
        set { _level = value; }
    }

    public int Count
    {
        get { return _count; }
        set { _count = value; }
    }


}
