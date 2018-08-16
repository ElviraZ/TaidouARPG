using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knapsack : UIBase
{

    EquipPopup equipPopup;
     InventoryPopup inventoryPopup;
    public override void Awake()
    {
        base.Awake();
        equipPopup = transform.Find("EquipPopup").GetComponent<EquipPopup>();
        inventoryPopup = transform.Find("InventoryPopup").GetComponent<InventoryPopup>();

    }

    public override void OnBtnClick(GameObject go)
    {
        base.OnBtnClick(go);
        switch (go.name)
        {
            case "BtnClose":
                BtnCloseClick();
                break;
            default:
                break;
        }
    }

    private void BtnCloseClick()
    {
        Close();
        nextOpenWindow = WindowUIType.Hide;
    }

    public void OnInventoryClick(object[] arr)
    {
        InventoryItem item = arr[0] as InventoryItem;
        bool isLeft = (bool)arr[1];

        InventoryItemUI itemUI = null;
        KnapsackRoleEquip roleEquip = null;
        if (isLeft)
        {
            itemUI=  arr[2] as InventoryItemUI;
        }
        else
        {
            roleEquip = arr[2] as KnapsackRoleEquip;
        }
      
        if (item.Inventory.InventoryType==InventoryType.Equip)
        {

            equipPopup.SetEquipPopup(arr[0] as InventoryItem,itemUI,roleEquip,isLeft);
        }
        else
        {
            InventoryItemUI itemUIdrug  = arr[2] as InventoryItemUI;
            inventoryPopup.SetInventoryPopup(arr[0] as InventoryItem, itemUIdrug);
        }
    }
}
