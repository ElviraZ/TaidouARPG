using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPopup : UIBase {
    public UISprite sprite;
    public UILabel nameLabel;
    public UILabel desLabel;

    private InventoryItem inventory = null;
    InventoryItemUI inventoryItemUI = null;
    public override void Awake()
    {
        base.Awake();

        sprite = transform.Find("Sprite").GetComponent<UISprite>();

        nameLabel = transform.Find("NameLabel").GetComponent<UILabel>();
       
        desLabel = transform.Find("DesLabel").GetComponent<UILabel>();

    }


    public override void OnBtnClick(GameObject go)
    {
        base.OnBtnClick(go);
        switch (go.name)
        { case "BtnUse":

                BtnUseClick();
                break;
            case "BtnUseBatching":
                BtnUseBatchingClick();
                break;
            case "BtnClosePopup":
                CloseBtnClick();
                break;
            default:
                break;
        }
    }
    private void CloseBtnClick()
    {
        Clear();
        this.gameObject.SetActive(false);
    }
    /// <summary>
    /// 批量使用-全部一起使用
    /// </summary>
    private void BtnUseBatchingClick()
    {
        UseClick(inventoryItemUI.Num);       
    }
    /// <summary>
    /// 使用一个
    /// </summary>
    private void BtnUseClick()
    {
        UseClick(1);

    }
    private void UseClick(int   num)
    {

        inventoryItemUI.ChangeCount(num);
        PlayerInfo.Instance.InventoryUse(inventory, num);
        Close();
    }
    public void SetInventoryPopup(InventoryItem item, InventoryItemUI itemUI)
    {
        this.gameObject.SetActive(true);
        this.inventory = item;
        this.inventoryItemUI = itemUI;
        sprite.spriteName = item.Inventory.Icon;
        nameLabel.text = item.Inventory.Name;
        desLabel.text = item.Inventory.Des;
    }
   void Clear()
    {
        this.inventory = null;
        this.inventoryItemUI = null;

    }
}
