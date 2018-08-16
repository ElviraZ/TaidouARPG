using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillPanel : UIBase
{
    UILabel desLabel;
    UILabel skillNameLabel;
    UILabel upgrateBtnLabel;
    UIButton upgrateBtn;

    private Skill m_skill;

    PlayerInfo playerInfo;
    public override void Awake()
    {
        base.Awake();
        skillNameLabel = transform.Find("SkillBg/SkillName").GetComponent<UILabel>();

        desLabel = transform.Find("SkillBg/DesLabel").GetComponent<UILabel>();
        upgrateBtnLabel = transform.Find("BtnUpgrate/Label").GetComponent<UILabel>();
        upgrateBtn = upgrateBtnLabel.gameObject.transform.parent.GetComponent<UIButton>();
        skillNameLabel.text = "";
        desLabel.text = "";
        UpgrateState(false, "请选择技能");
    }
    public override void Start()
    {
        base.Start();
        playerInfo = PlayerInfo.Instance;
    }
    public override void OnBtnClick(GameObject go)
    {
        base.OnBtnClick(go);
        switch (go.name)
        {
            case "btnClose":
                BtnCloseClick();
                break;
            case "BtnUpgrate":
                BtnUpgrateClick();
                break;
            default:
                break;
        }
    }

    private void BtnCloseClick()
    {
        Close();
        nextOpenWindow = WindowUIType.Hide;
    }

    void UpgrateState(bool isEnable, string label = "")
    {
        upgrateBtnLabel.text = label;
        if (isEnable)
        {
            upgrateBtn.SetState(UIButton.State.Normal, false);
            upgrateBtn.isEnabled = true;

        }
        else
        {
            upgrateBtn.SetState(UIButton.State.Disabled, false);
            upgrateBtn.isEnabled = false;
        }


    }

    public void OnSkillClick(Skill  skill)
    {


        m_skill = skill;
        skillNameLabel.text = skill.Name+"    Lv."+skill.Level;
        desLabel.text = "当前攻击力" + (skill.Damage * skill.Level) + "\n 下一级攻击力" + (skill.Damage * (skill.Level + 1))+"\n  升级所需金币="+ (500 * (skill.Level + 1));
        if (m_skill.Level > playerInfo.Level)
        {
            UpgrateState(false, "等级不足");
        }
     else   if (playerInfo.Coin<(500 * (skill.Level + 1)))
        {
            UpgrateState(false, "金币不足");

        }
        else
        {
            UpgrateState(true, "升级");
        }

    }
    private void BtnUpgrateClick()
    {
        if (m_skill!=null&&m_skill.Level<playerInfo.Level&& playerInfo.Coin >= (500 * (m_skill.Level + 1)))
        {
          
                m_skill.Level++;
                OnSkillClick(m_skill);
             playerInfo.GetCoin(500 * (m_skill.Level + 1));

        }
        else if ( m_skill.Level < playerInfo.Level )
        {
            UpgrateState(false, "等级不足");
        }
        else if (playerInfo.Coin < (500 * (m_skill.Level + 1)))
        {
            UpgrateState(false, "金币不足");
        }
    }
}
