using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// 总的物品信息
/// </summary>
public class Inventory
{
    /*
     * ID
名称
图标
类型（Equip，Drug）
装备类型
售价 
星级
品质
伤害
生命
战斗力
作用类型
作用值
描述

     * 
     * */
    private int id;
    private string name;
    private string icon;
    private InventoryType inventoryType;
    private EquipType equipType;

    private int price = 0;
    private int startLevel = 1;
    private int quality = 1;
    private int damage = 0;
    private int hp =0;
    private int power = 0;
    private InfoType infoType;
    private int applyValue;
    private string des;
    #region get/set   
    
    public int Id
    {
        get { return id; }
        set { id = value; }
    }
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    public string Icon
    {
        get { return icon; }
        set { icon = value; }
    }
    public InventoryType InventoryType
    {
        get { return inventoryType; }
        set { inventoryType = value; }
    }
    public EquipType EquipType
    {
        get { return equipType; }
        set { equipType = value; }
    }
    public int Price
    {
        get { return price; }
        set { price = value; }
    }
    public int StartLevel
    {
        get { return startLevel; }
        set { startLevel = value; }
    }
    public int Quality
    {
        get { return quality; }
        set { quality = value; }
    }

    public int Damage
    {
        get { return damage; }
        set { damage = value; }
    }
    public int Hp
    {
        get { return hp; }
        set { hp = value; }
    }
    public int Power
    {
        get { return power; }
set { power = value; }
    }
    public InfoType InfoType
    {
        get { return infoType; }
        set { infoType = value; }
    }
    public int ApplyValue
    {
        get { return applyValue; }
        set { applyValue = value; }
    }
    public string Des
    {
        get { return des; }
        set { des = value; }
    }
    #endregion
}
/// <summary>
/// 物品类型
/// </summary>
public enum InventoryType
{
    Equip,
    Drug,
    Box
}
/// <summary>
/// 装备类型
/// </summary>
public enum EquipType
{
    Helm,
    Cloth,
    Weapon,
    Shoes,
    Necklace,
    Bracelet,
    Ring,
    Wing

}
