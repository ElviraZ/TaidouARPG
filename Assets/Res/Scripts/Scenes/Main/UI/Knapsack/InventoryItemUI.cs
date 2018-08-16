using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemUI : MonoBehaviour
{
   public InventoryItem inventoryItem;
    private UISprite sprite;
    private UILabel numLabel;
    private int num;
    public int Num
    {
        get { return num; }
        set {
      
            num = value;
            if (num<=0)
            {
                Clear();
                InventoryManager.Instance.inventoryItemList.Remove(inventoryItem);
                NumLabel.gameObject.SetActive(false);

            }
            else
            {
                NumLabel.gameObject.SetActive(true);
                NumLabel.text = num.ToString();

            }
        }
    }
    public UISprite Sprite
    {
        get {
            if (sprite==null)
            {
                sprite = transform.Find("Sprite").GetComponent<UISprite>();
            }

            return sprite; }
        set { sprite = value; }
    }

    public UILabel NumLabel
    {
        get {
            if (numLabel == null)
            {
                numLabel = transform.Find("Label").GetComponent<UILabel>();
            }
            return numLabel; }
        set { numLabel = value; }
    }
    public void SetInventoryItemUI(InventoryItem   inventoryItem)
    {
        this.inventoryItem = inventoryItem;
        Sprite.spriteName = inventoryItem.Inventory.Icon;
        if (inventoryItem.Count >= 1)
        {
            Num = inventoryItem.Count;
            NumLabel.text = num.ToString();

        }

    }
    public void Clear()
    {
 inventoryItem =null;
        NumLabel.text = "";
        Sprite.spriteName = "bg_道具";
     
       
    }

    public void OnPress(bool isPress)
    {
        if (isPress&&inventoryItem!=null)
        {
            
                object[] arr = new object[3];
                arr[0] = this.inventoryItem;
                arr[1] = true;
            arr[2] = this;
            transform.parent.parent.parent.SendMessage("OnInventoryClick", arr, SendMessageOptions.RequireReceiver);
        }
    }

    public void ChangeCount(int count)
    {
        Num -= count;

    }
}
