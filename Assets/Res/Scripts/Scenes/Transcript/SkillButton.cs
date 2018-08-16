using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillButton : MonoBehaviour
{


 
    PlayerAnimation playerAnimation;
    public SkillPosType skillPosType = SkillPosType.Basic;


    public float coldTime = 4f;//技能的需要的冷却时间
    public float coldTimer = 0f;//剩余的冷却时间

    public UISprite maskSprite;
    UIButton thisBtn;

    private void Start()
    {
        playerAnimation = TranscriptController.Instance.playerAnimation;
        thisBtn = this.gameObject.GetComponent<UIButton>();
        if (skillPosType!=SkillPosType.Basic)
        {
            maskSprite = transform.Find("Mask").GetComponent<UISprite>();

        }
    }

    void OnPress(bool  isPress)
    {
        if (isPress&& skillPosType != SkillPosType.Basic)
        {
            coldTimer = coldTime;
            Disable();
        }
        playerAnimation.OnAttackButtonClick(isPress, skillPosType);
    }
    private void Update()
    {
        if (maskSprite==null)
        {
            return;
        }
        if (coldTimer>0)
        {
            coldTimer -= Time.deltaTime;
            maskSprite.fillAmount = coldTimer / coldTime;
        }
        else
        {
            maskSprite.fillAmount = 0;
            Able();
        }
    }
    private void Disable()
    {
        thisBtn.isEnabled = false;
        thisBtn.SetState(UIButtonColor.State.Normal, true);

    }
    private void Able()
    {
        thisBtn.isEnabled = true;
        thisBtn.SetState(UIButtonColor.State.Normal, true);
    }
}
