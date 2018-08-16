using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerPanel : UIBase
{



    public override void OnBtnClick(GameObject go)
    {
        base.OnBtnClick(go);
        switch (go.name)
        {
            case "btnClose":
                CloseClick();
                break;
            default:
                break;
        }
    }
    private void CloseClick()
    {
        Close();
        nextOpenWindow = WindowUIType.StartMenuPanel;

    }


}
