using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginPanel : UIBase
{

    UIInput nameInput;
    UIInput passwordInput;
     UILabel tipLabel;
    public override void Awake()
    {
        base.Awake();
        tipLabel = transform.Find("tipLabel").GetComponent<UILabel>();
        nameInput = transform.Find("NameInput").GetComponent<UIInput>();
        passwordInput = transform.Find("PasswordInput").GetComponent<UIInput>();

        tipLabel.gameObject.SetActive(false);

    }

    public override void OnBtnClick(GameObject go)
    {
        base.OnBtnClick(go);
        switch (go.name)
        {
            case "btnLogin":
                LoginClick();
                break;
            case "btnRegister":
               RegisterClick();
                break;
            case "btnClose":
                CloseClick();
                break;
            default:
                break;
        }
    }



    private void RegisterClick()
    {
        Close();
        nextOpenWindow = WindowUIType.RegisterPanel;
    }
    /// <summary>
    /// 登陆按钮点击
    /// </summary>
    private void LoginClick()
    {
        ////1.本地数据格式校验
        //string name = nameInput.value;
        //string password = passwordInput.value;
        //if (string.IsNullOrEmpty(name)||string.IsNullOrEmpty(password))
        //{
        // tipLabel.text= "账号或者密码不能为空";
        //    return;
        //}


        ////2.网络结果校验
        ////TODO

    }
    private void CloseClick()
    {
        Close();
        nextOpenWindow = WindowUIType.StartMenuPanel;

    }


}
