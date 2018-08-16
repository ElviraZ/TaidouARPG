using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegisterPanel : UIBase
{
    UIInput nameInput;
    UIInput passwordInput;
    UIInput repasswordInput;
    UILabel tipLabel;
    public override void Awake()
    {
        base.Awake();
        tipLabel = transform.Find("tipLabel").GetComponent<UILabel>();
        nameInput = transform.Find("NameInput").GetComponent<UIInput>();
        passwordInput = transform.Find("PasswordInput").GetComponent<UIInput>();
        repasswordInput = transform.Find("RePasswordInput").GetComponent<UIInput>();
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


    private void CloseClick()
    {
        Close();
        nextOpenWindow = WindowUIType.LoginPanel;
    }

    private bool CheckInput()
    {
        //1.本地数据格式校验
        string name = nameInput.value;
        string password = passwordInput.value;
        string repassword = repasswordInput.value;
        if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(repassword))
        {
            tipLabel.text = "账号或者密码不能为空";
            return false;
        }
        if (password != repassword)
        {
            tipLabel.text = "两次输入的密码不一致";
            return false;
        }
        return false;
        //2.网络结果校验
        //TODO
    }

    /// <summary>
    /// 注册并且登陆按钮点击
    /// </summary>
    private void RegisterClick()
    {
        CheckInput();
    }
    /// <summary>
    //登陆
    /// </summary>
    private void LoginClick()
    {
        CheckInput();

    }
}
