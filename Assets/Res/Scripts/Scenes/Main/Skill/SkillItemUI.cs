using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillItemUI : MonoBehaviour
{
    public SkillPosType skillPosType;
    private Skill skill;

    private UISprite sprite;
    public UISprite Sprite
    {
        get {

            if (sprite==null)
            {
                sprite = this.GetComponent<UISprite>();
            }
            return sprite; }
        set { sprite = value; }
    }

    private void Start()
    {
        Init();
    }
    public void Init()
    {
        skill = SkillManager.Instance.GetSkillByPosType(skillPosType);
        Sprite.spriteName = skill.Icon;
        this.GetComponent<UIButton>().normalSprite = skill.Icon;
        this.GetComponent<UIButton>().hoverSprite = skill.Icon;
        this.GetComponent<UIButton>().pressedSprite = skill.Icon;
        this.GetComponent<UIButton>().disabledSprite = skill.Icon;
    }
    void OnClick()
    {
     
            transform.parent.parent.SendMessage("OnSkillClick", this.skill);
        
    }
}
