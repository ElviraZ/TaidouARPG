using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : SingletonMono<InventoryUI>
{
    /// <summary>
    /// 所有的物品格子
    /// </summary>
    public List<InventoryItemUI> itemLists = new List<InventoryItemUI>();
    public override void Awake()
    {
        base.Awake();
        InventoryManager.Instance.OnInventoryChange += OnInventoryChange;

    }
    private void OnDestroy()
    {
        InventoryManager.Instance.OnInventoryChange -= OnInventoryChange;
    }
    private void OnInventoryChange()
    {
        UpdateInventoryUI();
    }

    private void UpdateInventoryUI()
    {
        for (int i = 0; i < InventoryManager.Instance.inventoryItemList.Count; i++)
        {
            InventoryItem it = InventoryManager.Instance.inventoryItemList[i];
            itemLists[i].SetInventoryItemUI(it);
        }
        for (int j = InventoryManager.Instance.inventoryItemList.Count; j < itemLists.Count; j++)
        {
            itemLists[j].Clear();
        }
    }
    public void AddInventory(InventoryItem  item)
    {
        foreach (InventoryItemUI itemUI in itemLists)
        {
            if (itemUI.inventoryItem==item)
            {
                //本身物品
                itemUI.Num++;
                break;
            }
            else if (itemUI.inventoryItem == null)
            {
                itemUI.SetInventoryItemUI(item);
                break;
            }
        }

    }
}
