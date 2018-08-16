using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuPanel : UIBase
{

    public override void Start()
    {
        base.Start();

    }
    public override void OnBtnClick(GameObject go)
    {
        base.OnBtnClick(go);
        switch (go.name)
        {
            case "btnuser":
                UserClick();
                break;
            case "btnserver":
                ServerClick();
                break;
            case "btnenter":

                EnterClick();

                break;
            default:
                break;
        }
    }

    private void UserClick()
    {
        Close();
        nextOpenWindow = WindowUIType.LoginPanel;

    }

    /// <summary>
    /// 服务器选择按钮点击
    /// </summary>
    private void ServerClick()
    {
        Close();
        nextOpenWindow = WindowUIType.ServerPanel;
    }
    /// <summary>
    ///进入游戏按钮点击
    /// </summary>
    private void EnterClick()
    {
        Close();
        nextOpenWindow = WindowUIType.CharacterSelectPanel;

    }


}
