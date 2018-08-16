using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : SingletonMono<PlayerInfo>
{
    #region    人物属性
    //    姓名
    //    头像
    //等级
    //战斗力
    //经验数
    //钻石数
    //金币数
    //体力数
    //历练数
    private string _name;

    private string _headPortrait;

    private int _level = 1;

    private int _power = 1;

    private int _exp = 0;
    private int _maxexp = 0;

    private int _diamond;

    private int _coin;

    private int _energy;
    private int _toughen;


    private int _maxenergy;
    private int _maxtoughen;

    private int _hp;
    private int _damage;


    private PlayerType playerType;

    //private int _helmID = 0;
    //private int _clothID = 0;
    //private int _weapnID = 0;
    //private int _shoesID = 0;
    //private int _necklaceID = 0;
    //private int _braceletID = 0;
    //private int _ringID = 0;
    //private int _wingID=0;
    public InventoryItem helmInventory;
    public InventoryItem clothInventory;
    public InventoryItem weaponInventory;
    public InventoryItem shoesInventory;
    public InventoryItem necklaceInventory;
    public InventoryItem braceletInventory;
    public InventoryItem ringInventory;
    public InventoryItem wingInventory;
    #endregion
    #region       GET  SET
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
    public string HeadPortrait
    {
        get { return _headPortrait; }
        set { _headPortrait = value; }
    }
    public int Level
    {
        get { return _level; }
        set { _level = value; }
    }
    public int Power
    {
        get { return _power; }
        set { _power = value; }
    }
    public int Exp
    {
        get { return _exp; }
        set { _exp = value; }
    }
    public int Maxexp
    {
        get { return GameController.GetRequiredExpByLevel(_level); }
        set { _maxexp = value; }
    }
    public int Diamond
    {
        get { return _diamond; }
        set { _diamond = value; }
    }
    public int Coin
    {
        get { return _coin; }
        set { _coin = value; }
    }
    public int Energy
    {
        get { return _energy; }
        set { _energy = value; }
    }
    public int Toughen
    {
        get { return _toughen; }
        set { _toughen = value; }
    }
    public int Maxenergy
    {
        get { return _maxenergy; }
        set { _maxenergy = value; }
    }

    public int Maxtoughen
    {
        get { return _maxtoughen; }
        set { _maxtoughen = value; }
    }
    public int Hp
    {
        get { return _hp; }
        set { _hp = value; }
    }

    public int Damage
    {
        get { return _damage; }
        set { _damage = value; }
    }

    //public int HelmID
    //{
    //    get { return _helmID; }
    //    set { _helmID = value; }
    //}

    //public int ClothID
    //{
    //    get { return _clothID; }
    //    set { _clothID = value; }
    //}

    //public int WeapnID
    //{
    //    get { return _weapnID; }
    //    set { _weapnID = value; }
    //}

    //public int ShoesID
    //{
    //    get { return _shoesID; }
    //    set { _shoesID = value; }
    //}

    //public int NecklaceID
    //{
    //    get { return _necklaceID; }
    //    set { _necklaceID = value; }
    //}

    //public int BraceletID
    //{
    //    get { return _braceletID; }
    //    set { _braceletID = value; }
    //}

    //public int RingID
    //{
    //    get { return _ringID; }
    //    set { _ringID = value; }
    //}

    //public int WingID
    //{
    //    get { return _wingID; }
    //    set { _wingID = value; }
    //}
    public PlayerType PlayerType
    {
        get { return playerType; }
        set { playerType = value; }
    }
    #endregion

    public delegate void OnPlayerInfoChangedEvent(InfoType  infoType);

    public event OnPlayerInfoChangedEvent OnPlayerInfoChanged;
    #region     Unity  Event
    [HideInInspector]
 public   float enemyTimer = 0f;

    [HideInInspector]
    public float toughenTimer = 0f;
    void Init()
    {
        this.Coin = 9999;
        this.Diamond = 999;
        this.Energy = 78;
        this.Maxenergy = 100;
        this.Exp = 123;

        this.HeadPortrait = "头像底板男性";
        this.Level =12;
        this.Name = "战神刑天";
        this.Power = 1111;
        this.Toughen = 34;
        this.Maxtoughen = 50;

        this.Hp = Level * 100;
        this.Damage = Level * 50;
        this.Power = Hp + Damage;

        //this.BraceletID = 1001;
        //this.WingID = 1002;
        //this.RingID = 1003;
        //this.ClothID = 1004;
        //this.HelmID = 1005;
        //this.WeapnID = 1006;
        //this.NecklaceID = 1007;
        //this.ShoesID = 1008;
        if (OnPlayerInfoChanged!=null)
        {
            OnPlayerInfoChanged(InfoType.All);

        }


    }

  
    void Start()
    {
        Init();
    }


   void InitEquip()
    {

    }
    private void Update()
    {
        if (this.Energy<100)
        {
            enemyTimer+=Time.deltaTime;
            if (enemyTimer>60)
            {
                Energy += 1;
                enemyTimer -= 60;
                OnPlayerInfoChanged(InfoType.Energy);
            }
        }
        else
        {
            enemyTimer = 0;
        }

        if (this.Toughen < 50)
        {
            toughenTimer += Time.deltaTime;
            if (toughenTimer > 60)
            {
                Toughen += 1;
                toughenTimer -= 60;
                OnPlayerInfoChanged(InfoType.Toughen);
            }
        }
        else
        {
            toughenTimer = 0;
        }


        if (Input.GetMouseButtonDown(1))
        {
            WindowUIMgr.Instance.OpenWindow(WindowUIType.PlayerStatus, GameObject.Find("UI Root").transform);
    
        }
    }

    internal void ChangeName(string strName)
    {
        if (this.Name!=strName)
        {
            this.Name = strName;
            OnPlayerInfoChanged(InfoType.Name);
        }
    }
    #endregion


    #region   装备的穿戴
    /// <summary>
    /// 穿上
    /// </summary>
    /// <param name="id"></param>
    public void PutOnEquip(InventoryItem item )
    {
        item.Dressed = true;
        //检查同位置是否有装备
        bool isDressed = false;

        InventoryItem dressedInventory = null;
        switch (item.Inventory.EquipType)
        {
            case EquipType.Helm:
                if (helmInventory!=null)
                {
                    isDressed = true;
                    dressedInventory = helmInventory;
                   
                }
            helmInventory = item;
                break;
            case EquipType.Cloth:
                if (clothInventory != null)
                {
                    isDressed = true;
                    dressedInventory = clothInventory;
                   
                } clothInventory = item;
                break;
            case EquipType.Weapon:
                if (weaponInventory != null)
                {
                    isDressed = true;
                    dressedInventory = weaponInventory;
               
                }
                weaponInventory = item;
                break;
            case EquipType.Shoes:
                if (shoesInventory != null)
                {
                    isDressed = true;
                    dressedInventory = shoesInventory;
                   
                }
                shoesInventory = item;
                break;
            case EquipType.Necklace:
                if (necklaceInventory != null)
                {
                    isDressed = true;
                    dressedInventory = necklaceInventory;

                }
                necklaceInventory = item;
                break;
            case EquipType.Bracelet:
                if (braceletInventory != null)
                {
                    isDressed = true;
                    dressedInventory = braceletInventory;
                
                }
                braceletInventory = item;
                break;
            case EquipType.Ring:
                if (ringInventory != null)
                {
                    isDressed = true;
                    dressedInventory = ringInventory;
                }
                ringInventory = item;
                break;
            case EquipType.Wing:
                if (wingInventory != null)
                {
                    isDressed = true;
                    dressedInventory = wingInventory;
          
                }
                wingInventory = item;
                break;
            default:
                break;
        }

        //有，脱下
        if (isDressed==true)
        {
            dressedInventory.Dressed = false;
            InventoryUI.Instance.AddInventory(dressedInventory);
        }
        OnPlayerInfoChanged(InfoType.Equip);
    }
    /// <summary>
    /// 脱下
    /// </summary>
    /// <param name="id"></param>
    public void PutOffEquip(InventoryItem item)
    {
        switch (item.Inventory.EquipType)
        {
            case EquipType.Helm:
           
                helmInventory = null;
                break;
            case EquipType.Cloth:
           
                clothInventory = null;
                break;
            case EquipType.Weapon:
             
                weaponInventory = null;
                break;
            case EquipType.Shoes:
            
                shoesInventory = null;
                break;
            case EquipType.Necklace:
             
                necklaceInventory = null;
                break;
            case EquipType.Bracelet:
                if (braceletInventory != null)
              
                braceletInventory = null;
                break;
            case EquipType.Ring:
            ringInventory = null;
                break;
            case EquipType.Wing:
              
                wingInventory = null;
                break;
            default:
                break;
        }
        item.Dressed = false;
        InventoryUI.Instance.AddInventory(item);
        OnPlayerInfoChanged(InfoType.Equip);
    }


    public bool GetCoin(int count)
    {
        if (Coin>=count)
        {
            Coin -= count;
            OnPlayerInfoChanged(InfoType.Coin);
            return true;
        }
        return false;
    }

    /// <summary>
    /// 使用物品=药品
    /// </summary>
    /// <param name="item"></param>
    /// <param name="count"></param>
    public void InventoryUse(InventoryItem  item,int count)
    {
        Hp += count * item.Inventory.Hp;
        Damage += count * item.Inventory.Damage;
        Power += count * item.Inventory.Power;

        OnPlayerInfoChanged(InfoType.HP);
        OnPlayerInfoChanged(InfoType.Damage);
        OnPlayerInfoChanged(InfoType.Power);

    }

    #endregion
}
