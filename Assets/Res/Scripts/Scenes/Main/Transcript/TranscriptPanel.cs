using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranscriptPanel : UIBase {



    public override void OnBtnClick(GameObject go)
    {
        base.OnBtnClick(go);
        switch (go.name)
        {
            case "BtnBack":
                BtnBackClick();
                break;
            default:
                break;
        }
    }

 

    private void BtnBackClick()
    {
        Close();
        nextOpenWindow = WindowUIType.Hide;
    }
    public void TranscriptBtnClick(int   id)
    {

       GameObject go= WindowUIMgr.Instance.OpenWindow(WindowUIType.TranscriptPanelDialog,this.transform.parent);
        go.GetComponent<TranscriptPanelDialog>().Init(id);

    }


}
