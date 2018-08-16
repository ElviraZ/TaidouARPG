using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator anim;
    Rigidbody rigi;
    float velocity = 0.0f;

    void Start()
    {
        anim = GetComponent<Animator>();
        rigi = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if (rigi != null)
        {
            velocity = rigi.velocity.magnitude;
        }

        if (velocity > 0.01f || (ETCInput.GetAxis("Vertical") != 0 || ETCInput.GetAxis("Horizontal") != 0))
        {
            if (anim.GetCurrentAnimatorStateInfo(1).IsName("EmptyState"))
            {
    anim.SetBool("Move", true);
            }
        
        }
        else
        {
            anim.SetBool("Move", false);
        }

    }



    public void OnAttackButtonClick(bool  isPress,SkillPosType  skillPosType)
    {
      
        if (skillPosType==SkillPosType.Basic)
        {
            if (isPress)
            {
                anim.SetTrigger("Attack");
            }
        }
        else
        {
            if (isPress)
            {
       anim.SetBool("Skill"+(int)skillPosType, true);
            }
        }
    }
    /// <summary>
    /// 动画帧里面处理的动画结束事件
    /// </summary>
    /// <param name="skillPosType"></param>
    public void OnAttackButtonClickEnd(int skillPosType)
    {
       
        anim.SetBool("Skill" + skillPosType, false);
    }
}
