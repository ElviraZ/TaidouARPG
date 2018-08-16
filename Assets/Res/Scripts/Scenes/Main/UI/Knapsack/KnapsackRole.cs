using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnapsackRole : SingletonMono<KnapsackRole>
{

    private KnapsackRoleEquip helmEquip;
    private KnapsackRoleEquip clothEquip;
    private KnapsackRoleEquip weaponEquip;
    private KnapsackRoleEquip shoesEquip;
    private KnapsackRoleEquip necklaceEquip;
    private KnapsackRoleEquip braceletEquip;
    private KnapsackRoleEquip ringEquip;
    private KnapsackRoleEquip wingEquip;


    UILabel hpLabel;
    UILabel damageLabel;
    UISlider expSlider;
    UILabel expLabel;



    public override void Awake()
    {
        base.Awake();
        helmEquip = transform.Find("HelmSprite").GetComponent<KnapsackRoleEquip>();
        clothEquip = transform.Find("ClothSprite").GetComponent<KnapsackRoleEquip>();
        weaponEquip = transform.Find("WeaponSprite").GetComponent<KnapsackRoleEquip>();
        shoesEquip = transform.Find("ShoesSprite").GetComponent<KnapsackRoleEquip>();
        necklaceEquip = transform.Find("NecklaceSprite").GetComponent<KnapsackRoleEquip>();
        braceletEquip = transform.Find("BraceletSprite").GetComponent<KnapsackRoleEquip>();
        ringEquip = transform.Find("RingSprite").GetComponent<KnapsackRoleEquip>();
        wingEquip = transform.Find("WingSprite").GetComponent<KnapsackRoleEquip>();


        hpLabel = transform.Find("HP/Label").GetComponent<UILabel>();
        damageLabel = transform.Find("Damage/Label").GetComponent<UILabel>();
        expLabel = transform.Find("Exp/Label").GetComponent<UILabel>();
        expSlider = transform.Find("Exp").GetComponent<UISlider>();
    }
    void Start ()
    {
        PlayerInfo.Instance.OnPlayerInfoChanged += OnPlayerInfoChanged;
	}

    private void OnPlayerInfoChanged(InfoType infoType)
    {
        switch (infoType)
        {
    
            case InfoType.Level:
            case InfoType.Power:
            case InfoType.Exp:
            case InfoType.HP:
            case InfoType.Damage:
            case InfoType.All:
            case InfoType.Equip:
                UpdatePropperty();
                break;
            default:
                break;
        }
    }

    private void UpdatePropperty()
    {
        PlayerInfo info = PlayerInfo.Instance;
    
        hpLabel.text = info.Hp.ToString();
        damageLabel.text = info.Damage.ToString();
        expLabel.text = info.Exp.ToString()+"/"+ GameController.GetRequiredExpByLevel(info.Level + 1);
        expSlider.value =(float) info.Exp / GameController.GetRequiredExpByLevel(info.Level + 1);
        //helmEquip.Setid(info.HelmID);
        //clothEquip.Setid(info.ClothID);
        //weaponEquip.Setid(info.WeapnID);
        //ringEquip.Setid(info.RingID);
        //shoesEquip.Setid(info.ShoesID);
        //necklaceEquip.Setid(info.NecklaceID);
        //braceletEquip.Setid(info.BraceletID);
        //wingEquip.Setid(info.WingID);



        helmEquip.SetInventoryItem(info.helmInventory);
        clothEquip.SetInventoryItem(info.clothInventory);
        weaponEquip.SetInventoryItem(info.weaponInventory);
        ringEquip.SetInventoryItem(info.ringInventory);
        shoesEquip.SetInventoryItem(info.shoesInventory);
        necklaceEquip.SetInventoryItem(info.necklaceInventory);
        braceletEquip.SetInventoryItem(info.braceletInventory);
        wingEquip.SetInventoryItem(info.wingInventory);
    }
    private void OnDestroy()
    {
        PlayerInfo.Instance.OnPlayerInfoChanged -= OnPlayerInfoChanged;
    }
    // Update is called once per frame
    void Update ()
    {
		
	}
}
