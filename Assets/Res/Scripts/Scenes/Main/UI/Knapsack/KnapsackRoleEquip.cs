using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnapsackRoleEquip : MonoBehaviour {
    UISprite sprite;
    public UISprite Sprite
    {
        get {
            if (sprite==null)
            {
                sprite = GetComponent<UISprite>();
            }

            return sprite; }
        set { sprite = value; }
    }
    InventoryItem inventoryItem;
 public   void Setid(int id)
    {
        InventoryManager im = InventoryManager.Instance;
        Inventory inventory = null;
        if (im.inventoryDic.TryGetValue(id, out inventory))
        {
            Sprite.spriteName = inventory.Icon;
        }
    }
    public void SetInventoryItem(InventoryItem  item)
    {
        if (item==null)
        {
            return;

        }
        this.inventoryItem = item;
        Sprite.spriteName = item.Inventory.Icon;
    }


    public void OnPress(bool isPress)
    {
        if (isPress&&inventoryItem!=null)
        {
            object[] arr = new object[3];
            arr[0] = this.inventoryItem;
            arr[1] = false;
            arr[2] = this;
            transform.parent.parent.SendMessage("OnInventoryClick", arr, SendMessageOptions.RequireReceiver);
        }
    }

    public void Clear()
    {
        inventoryItem = null;
        Sprite.spriteName = "bg_道具";
    }
}
