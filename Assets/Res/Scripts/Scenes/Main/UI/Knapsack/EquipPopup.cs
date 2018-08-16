using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipPopup : UIBase
{

    public UISprite sprite;
    public UILabel nameLabel;
    public UILabel qualityLabel;
    public UILabel damageLabel;
    public UILabel hpLabel;
    public UILabel powerLabel;
    public UILabel desLabel;
    public UILabel levelLabel;



    UIButton toggleStatebtn;
    UILabel btnLabel;
    private InventoryItem inventory=null;
    InventoryItemUI inventoryItemUI = null;
    KnapsackRoleEquip roleEquip = null;
    bool isLeft = true;
    public override void Awake()
    {
        base.Awake();

        sprite = transform.Find("Sprite").GetComponent<UISprite>();

        nameLabel = transform.Find("NameLabel").GetComponent<UILabel>();
        qualityLabel = transform.Find("Quality/Label").GetComponent<UILabel>();
        damageLabel = transform.Find("Damage/Label").GetComponent<UILabel>();
        hpLabel = transform.Find("HP/Label").GetComponent<UILabel>();
        powerLabel = transform.Find("Power/Label").GetComponent<UILabel>();
        levelLabel = transform.Find("Level/Label").GetComponent<UILabel>();
        desLabel = transform.Find("DesLabel").GetComponent<UILabel>();
        toggleStatebtn = transform.Find("BtnEquip").GetComponent<UIButton>();
        btnLabel=toggleStatebtn.gameObject.transform.Find("Label").GetComponent<UILabel>();
    }





    public override void OnBtnClick(GameObject go)
    {
        base.OnBtnClick(go);
        switch (go.name)
        {
            case "BtnEquip":
                BtnEquipClick();
                break;
            case "BtnUpgrate":
                BtnUpgrateClick();
                break;
            case "BtnClosePopup":

                CloseBtnClick();
                break;
            default:
                break;
        }
    }
    /// <summary>
    /// 升级装备
    /// </summary>
    private void BtnUpgrateClick()
    {
    
        int coinNeed = inventory.Inventory.Price * (inventory.Level + 1);
        bool isSuccess = PlayerInfo.Instance.GetCoin(coinNeed);
        if (isSuccess)
        {
            Debug.Log("dfgfdgdfg");
            inventory.Level++;
            levelLabel.text = inventory.Level.ToString();
        }
        else
        {
            Debug.Log("金币不足");
            MessageManager.Instance.SetMessage("金币不足");
            //金币不足
        }
    }

   
    private void BtnEquipClick()
    {
        if (isLeft)
        {
            PlayerInfo.Instance.PutOnEquip(inventory);
            inventoryItemUI.Num--;
        }

        else
        {
            PlayerInfo.Instance.PutOffEquip(inventory);

        }

    
        Clear();
        this.gameObject.SetActive(false);
    }

    private void CloseBtnClick()
    {
        inventory = null;
        this.gameObject.SetActive(false);
    }
    public void  SetEquipPopup(InventoryItem item,InventoryItemUI  itemUI,KnapsackRoleEquip roleEquip,bool   isLeft=true)
    {
        this.gameObject.SetActive(true);
        this.isLeft = isLeft;
        if (isLeft==true)
        {
            this.transform.position = Vector3.zero;
            btnLabel.text = "装备";
        }
        else
        {
            this.transform.localPosition = new Vector3(500f,0f,0f);
            btnLabel.text = "卸下";
        }
        this.inventory = item;
        this.inventoryItemUI = itemUI;
        this.roleEquip = roleEquip;
        sprite.spriteName = item.Inventory.Icon;
        nameLabel .text= item.Inventory.Name;
        qualityLabel.text = item.Inventory.Quality.ToString();
        damageLabel.text = item.Inventory.Damage.ToString();
        hpLabel.text = item.Inventory.Hp.ToString();
        powerLabel.text = item.Inventory.Power.ToString();
        desLabel.text = item.Inventory.Des;
        levelLabel.text = item.Level.ToString();
    }
    void Clear()
    {
        if (inventoryItemUI != null)
        {
            inventoryItemUI = null;

        }
        if (inventory != null)
        {
            inventory = null;

        }
        if (roleEquip!=null)
        {
            roleEquip.Clear();

        }
    }
}
