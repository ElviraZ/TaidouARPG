using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BattleOverPanel : UIBase
{
    public override void Awake()
    {
        base.Awake();
    }

    public override void OnBtnClick(GameObject go)
    {
        base.OnBtnClick(go);
        switch (go.name)
        {
            case "Btnback":
                BtnbackClick();
                break;
            default:
                break;
        }
    }

    private void BtnbackClick()
    {
        Close();
        GameDatas.NextSceneName = "2mainmenu";
        SceneManager.LoadScene("0Loading");
    }
}
