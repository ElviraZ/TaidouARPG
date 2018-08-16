using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBar : UIBase
{
     UISprite headSprite;
     UILabel nameLabel;
     UILabel levelLabel;
     UISlider energySlider;
     UISlider toughenSlider;
     UILabel energyLabel;
     UILabel toughenLabel;



    public override void Awake()
    {
        base.Awake();
        headSprite = transform.Find("HeadSprite").GetComponent<UISprite>();
        nameLabel = transform.Find("NameLabel").GetComponent<UILabel>();
        levelLabel = transform.Find("LevelLabel").GetComponent<UILabel>();
        energySlider = transform.Find("EnegyProressBar").GetComponent<UISlider>();
        toughenSlider = transform.Find("toughenProressBar").GetComponent<UISlider>();
        energyLabel = transform.Find("EnegyProressBar/Label").GetComponent<UILabel>();
        toughenLabel = transform.Find("toughenProressBar/Label").GetComponent<UILabel>();
        PlayerInfo.Instance.OnPlayerInfoChanged += OnPlayerInfoChanged;


    }



    public override void OnBtnClick(GameObject go)
    {
        base.OnBtnClick(go);
        switch (go.name)
        {
            case "EnegyPlusBtn":
                EnegyPlusBtnClick();
                break;
            case "toughenPlusBtn":
                ToughenPlusBtnClick();
                break;
            default:
                break;
        }
    }


    public override void Start()
    {
        base.Start();

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
        headSprite.name = info.HeadPortrait;
        nameLabel.text = info.Name;
        levelLabel.text = info.Level.ToString();
        energySlider.value = (float)info.Energy / info.Maxenergy;
        toughenSlider.value = (float)info.Toughen / info.Maxtoughen;
        energyLabel.text = info.Energy.ToString()+"/"+ info.Maxenergy.ToString();
        toughenLabel.text = info.Toughen.ToString() + "/" + info.Maxtoughen.ToString();

    }

    private void ToughenPlusBtnClick()
    {
    }

    private void EnegyPlusBtnClick()
    {
    }
}
