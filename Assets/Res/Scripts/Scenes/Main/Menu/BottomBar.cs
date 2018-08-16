using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomBar : UIBase {

    public override void OnBtnClick(GameObject go)
    {
        base.OnBtnClick(go);
        switch (go.name)
        {
            case "Combat":
                CombatClick();
                break;
            case "Knapsack":
                KnapsackClick();
                break;
            case "Task":
                TaskClick();
                break;
            case "Skill":
                SkillClick();
                break;
            case "Shop":
                ShopClick();
                break;
            case "System":
                SystemClick();
                break;
            default:
                break;
        }
    }

    private void CombatClick()
    {
        WindowUIMgr.Instance.OpenWindow(WindowUIType.TranscriptPanel,this.transform.parent);
    }
    private void KnapsackClick()
    {
        WindowUIMgr.Instance.OpenWindow(WindowUIType.KnapsackPanel,this.transform.parent);
    }
    private void TaskClick()
    {
    }
    private void SkillClick()
    {
        WindowUIMgr.Instance.OpenWindow(WindowUIType.SkillPanel, this.transform.parent);
    }
    private void ShopClick()
    {
    }
    private void SystemClick()
    {
    }




}
