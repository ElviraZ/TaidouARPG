using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
public class InventoryManager : SingletonMono<InventoryManager>
{
    public TextAsset listInfo;

    public Dictionary<int, Inventory> inventoryDic = new Dictionary<int, Inventory>();
    public List< InventoryItem> inventoryItemList= new List<InventoryItem>();
    public delegate void OnInventoryChangeEvent();
    public event OnInventoryChangeEvent OnInventoryChange;
    public override void Awake()
    {
        base.Awake();
        ReadInventoryInfo();
     
    }
    private void Start()
    {
           ReadInventoryItemInfo();
    }

    /// <summary>
    /// 读取总的物品信息
    /// </summary>
    void ReadInventoryInfo()
    {
        string str = listInfo.ToString();
        string[] itemStrArray = str.Split('\n');
        foreach (string itemStr in itemStrArray)
        {
            string[] proArray = itemStr.Split('|');

            Inventory inventory = new Inventory();
            inventory.Id = int.Parse(proArray[0]);
            inventory.Name = proArray[1];
            inventory.Icon = proArray[2];
            switch (proArray[3])
            {
                case "Equip":
                    {
                        inventory.InventoryType = InventoryType.Equip;
                        switch (proArray[4])
                        {
                            case "Helm":
                                inventory.EquipType = EquipType.Helm;
                                break;
                            case "Bracelet":
                                inventory.EquipType = EquipType.Bracelet;
                                break;
                            case "Cloth":
                                inventory.EquipType = EquipType.Cloth;
                                break;
                            case "Necklace":
                                inventory.EquipType = EquipType.Necklace;
                                break;
                            case "Ring":
                                inventory.EquipType = EquipType.Ring;
                                break;
                            case "Shoes":
                                inventory.EquipType = EquipType.Shoes;
                                break;
                            case "Weapon":
                                inventory.EquipType = EquipType.Weapon;
                                break;
                            case "Wing":
                                inventory.EquipType = EquipType.Wing;
                                break;
                            default:
                                break;
                        }

                        inventory.StartLevel = int.Parse(proArray[6]);
                        inventory.Quality = int.Parse(proArray[7]);
                        inventory.Damage = int.Parse(proArray[8]);
                        inventory.Hp = int.Parse(proArray[9]);
                        inventory.Power = int.Parse(proArray[10]);
                    }
                    break;
                case "Drug":
                    inventory.InventoryType = InventoryType.Drug;
                    inventory.ApplyValue = int.Parse(proArray[12]);
                    break;
                case "Box":
                    inventory.InventoryType = InventoryType.Box;
                    break;

                default:
                    break;
            }

            inventory.Price = int.Parse(proArray[5]);
            inventory.Des = proArray[13];
            inventoryDic.Add(inventory.Id, inventory);
        }

    }

    /// <summary>
    /// 读取当前角色拥有的物品信息,
    /// </summary>
    void ReadInventoryItemInfo()
    {
   
        //测试，随机生成主角的物品
        for (int i = 0; i < 20; i++)
        {
     bool isExit = false;
            int id = Random.Range(1001, 1020);
            InventoryItem inventoryItem = null;
            Inventory it = null;

          
            foreach (InventoryItem item in inventoryItemList)
            {
                if (item.Inventory.Id==id)
                {
                    isExit = true;
                    inventoryItem =item;
                    break;
                }
            }
            if (isExit)
            {//如果背包中存在
                inventoryItem.Count++;
            }
            else
            {
                inventoryItem = new InventoryItem();
                it = inventoryDic[id];

                inventoryItem.Inventory = it;
                inventoryItem.Level = Random.Range(1, 10);
                inventoryItem.Count = 1;
                inventoryItemList.Add( inventoryItem);
            }


        }
        if (OnInventoryChange!=null)
        {
            OnInventoryChange();

        }
    }
}
