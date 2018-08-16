using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogPanel : UIBase {
    private int id;
    UISprite sprite;
    UILabel desLabel;



    public override void Awake()
    {
        base.Awake();
        sprite = transform.Find("Sprite").GetComponent<UISprite>();
        desLabel = transform.Find("DesLabel").GetComponent<UILabel>();
    }

    public override void OnBtnClick(GameObject go)
    {
        base.OnBtnClick(go);
        switch (go.name)
        {
            case "BtnAccept":
                BtnAcceptClick();
                break;
            default:
                break;
        }
    }

    private void BtnAcceptClick()
    {
        Close();
        nextOpenWindow = WindowUIType.Hide;
    }

    public void Init( int id, string desString, string spriteIconStr)
    {
        this.id = id;
        desLabel.text = desString;
        sprite.spriteName = spriteIconStr;
    }

    public void OutTrigger()
    {
        Close();
        nextOpenWindow = WindowUIType.Hide;
    }


}
