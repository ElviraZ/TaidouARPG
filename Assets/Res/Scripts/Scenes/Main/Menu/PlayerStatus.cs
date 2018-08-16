using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : UIBase
{

    UISprite headSprite;
    UILabel nameLabel;
    UILabel levelLabel;
    UILabel powerLabel;
    UISlider expSlider;
    UILabel expLabel;
    UILabel goldLabel;
     UILabel diamondLabel;


    UILabel energyLabel;
    UILabel energyRestorePartLabel;
    UILabel energyRestoreAllLabel;

    UILabel toughenLabel;
    UILabel toughenRestorePartLabel;
    UILabel toughenRestoreAllLabel;



    GameObject changeNameBg;
    UIInput nameInput;
    public override void Awake()
    {
        base.Awake();

        headSprite = transform.Find("container/HeadSprite").GetComponent<UISprite>();
        nameLabel = transform.Find("container/NameLabel").GetComponent<UILabel>();
        levelLabel = transform.Find("container/LevelLabel").GetComponent<UILabel>();
        powerLabel = transform.Find("container/PowerLabel").GetComponent<UILabel>();
        expSlider = transform.Find("container/ExpProgressBar").GetComponent<UISlider>();
        expLabel = transform.Find("container/ExpProgressBar/ExpLabel").GetComponent<UILabel>();
        goldLabel = transform.Find("container/Container/Grid/goldbg/GoldLabel").GetComponent<UILabel>();
        diamondLabel = transform.Find("container/Container/Grid/diamondbg/DiamondLabel").GetComponent<UILabel>();

        energyLabel = transform.Find("container/EnergyContainer/NumLabel").GetComponent<UILabel>();
        energyRestorePartLabel = transform.Find("container/EnergyContainer/RestorePartTime").GetComponent<UILabel>();
        energyRestoreAllLabel = transform.Find("container/EnergyContainer/RestorePartAll").GetComponent<UILabel>();

        toughenLabel = transform.Find("container/ToughenContainer/NumLabel").GetComponent<UILabel>();
        toughenRestorePartLabel = transform.Find("container/ToughenContainer/RestorePartTime").GetComponent<UILabel>();
        toughenRestoreAllLabel = transform.Find("container/ToughenContainer/RestorePartAll").GetComponent<UILabel>();


        nameInput = transform.Find("changeNameBg/NameInput").GetComponent<UIInput>();
        changeNameBg = transform.Find("changeNameBg").gameObject;
        changeNameBg.SetActive(false);
    }

    public override void OnBtnClick(GameObject go)
    {
        base.OnBtnClick(go);
        switch (go.name)
        {
            case "btnChangeName":
                BtnChangeNameClick();
                break;
            case "BtnClose":
                BtnCloseClick();
                break;
            case "changeSure":
                ChangeSureClick();
                break;
            case "ChangeCancel":
                ChangeCancelClick();
                break;
            default:
                break;
        }
    }

    private void ChangeCancelClick()
    {
        changeNameBg.SetActive(false);
    }

    private void ChangeSureClick()
    {
        string strName = nameInput.value;
        if (string.IsNullOrEmpty(strName))
        {
            return;
        }
        PlayerInfo.Instance.ChangeName(strName);
        changeNameBg.SetActive(false);
    }

    private void BtnCloseClick()
    {
       
        Close();
        nextOpenWindow = WindowUIType.Hide;
    }

    private void BtnChangeNameClick()
    {
        changeNameBg.SetActive(true);
    }


    public override void Start()
    {
        base.Start();
        PlayerInfo.Instance.OnPlayerInfoChanged += OnPlayerInfoChanged;
        UpdateProperty();
    }
    private void OnDestroy()
    {
        PlayerInfo.Instance.OnPlayerInfoChanged -= OnPlayerInfoChanged;
    }

    void OnPlayerInfoChanged(InfoType type)
    {
        switch (type)
        {
            case InfoType.All:
            case InfoType.Name:
            case InfoType.HeadPortrait:
            case InfoType.Level:
            case InfoType.Energy:
            case InfoType.Toughen:
                UpdateProperty();

                break;
            default:
                break;
        }
    }

    private void UpdateProperty()
    {
        PlayerInfo info = PlayerInfo.Instance;
        headSprite.spriteName = info.HeadPortrait;
        nameLabel.text = info.Name;
        levelLabel.text = info.Level.ToString();
        powerLabel.text = info.Power.ToString();
        expSlider.value = (float)info.Exp / info.Maxexp;
        expLabel.text = info.Exp.ToString() + "/" + info.Maxexp.ToString();
        goldLabel.text = info.Coin.ToString();
        diamondLabel.text = info.Diamond.ToString();
        UpdateEnergyAndToughen();



    }
    /// <summary>
    /// 更新体力和历练的显示
    /// </summary>
   void UpdateEnergyAndToughen()
    {
        PlayerInfo info = PlayerInfo.Instance;
        energyLabel.text = info.Energy + "/100";

        if (info.Energy>=100)
        {
            energyRestorePartLabel.text = "00:00:00";
            energyRestoreAllLabel.text = "00:00:00";
        }
        else
        {
            //计算一点回复的时间
            int  remainTime = 60 - (int)info.enemyTimer;
            string str = remainTime <= 9 ? "0" + remainTime : remainTime.ToString();
            energyRestorePartLabel.text = "00:00:" + str;
            //计算全部恢复需要的时间
            int minues = 99 - info.Energy;
            int hours = minues / 60;
            minues = minues % 60;
            string strHour = hours <= 9 ? "0" + hours : hours.ToString();
            string strmnutes = minues <= 9 ? "0" + minues : minues.ToString();
            energyRestoreAllLabel.text = strHour + ":"+strmnutes+":"+str;

        }



        toughenLabel.text = info.Toughen + "/50";
        if (info.Toughen >= 50)
        {
            toughenRestorePartLabel.text = "00:00:00";
            toughenRestoreAllLabel.text = "00:00:00";
        }
        else
        {
            //计算一点回复的时间
            int remainTime = 60 - (int)info.toughenTimer;
            string str = remainTime <= 9 ? "0" + remainTime.ToString() : remainTime.ToString();
            toughenRestorePartLabel.text = "00:00:" + str;
            //计算全部恢复需要的时间
            int minues = 49 - info.Toughen;
            int hours = minues / 60;
            minues = minues % 60;
            string strHour = hours <= 9 ? "0" + hours.ToString() : hours.ToString();
            string strmnutes = minues <= 9 ? "0" + minues.ToString() : minues.ToString();
            toughenRestoreAllLabel.text = strHour + ":" + strmnutes + ":" + str;

        }
    }

    private void Update()
    {
        UpdateEnergyAndToughen();
    }
}
