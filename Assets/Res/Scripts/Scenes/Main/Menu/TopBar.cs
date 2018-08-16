using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopBar : UIBase
{
     UILabel goldLabel;
     UILabel diamondLabel;

    public override void Awake()
    {
        base.Awake();
        goldLabel = transform.Find("goldbg/goldLabel").GetComponent<UILabel>();
        diamondLabel = transform.Find("diamondbg/diamondLabel").GetComponent<UILabel>();
        PlayerInfo.Instance.OnPlayerInfoChanged += OnPlayerInfoChanged;

    }

    public override void OnBtnClick(GameObject go)
    {
        base.OnBtnClick(go);
        switch (go.name)
        {
            case "goldPlusBtn":
                GoldPlusBtnClick();
                break;
            case "diamondPlusBtn":
                DiamondPlusBtnClick();
                break;
            default:
                break;
        }
    }

    private void DiamondPlusBtnClick()
    {
    }

    private void GoldPlusBtnClick()
    {
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
            case InfoType.Coin:
            case InfoType.Diamond:
                UpdateProperty();

                break;
            default:
                break;
        }
    }

    private void UpdateProperty()
    {
        PlayerInfo info = PlayerInfo.Instance;
   
        goldLabel.text = info.Coin.ToString();
        diamondLabel.text = info.Diamond.ToString();
      
    }

}
