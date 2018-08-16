using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
public class PlayerAttack : MonoBehaviour
{

    private Dictionary<string, PlayerEffect> effectDic = new Dictionary<string, PlayerEffect>();

    public List<GameObject> enemyList = new List<GameObject>();


    public PlayerEffect[] effctArray;

    private int[] damageArray = new int[4] { 20, 30, 30, 30 };
    float attackDistanceForward = 4f;
    float attackDistanceAround =4f;

    Animator anim;
    protected GameObject hpbarGo;
    protected UISlider hpBarSlider;
    protected GameObject hudTextGo;
    protected HUDText hUDText;
    public int hp = 200;
    public int hpTotal;
    private void Start()
    {
        hpTotal = hp;
        PlayerEffect[] peArray = GetComponentsInChildren<PlayerEffect>();
        foreach (var item in peArray)
        {
            effectDic.Add(item.name, item);
        }
        foreach (var item in effctArray)
        {
            effectDic.Add(item.name, item);
        }
        anim = GetComponent<Animator>();
        hpbarGo = HpBarManager.Instance.GetHpBar(this.gameObject.transform.Find("HpBarPoint"));
        hudTextGo = HpBarManager.Instance.GetHudText(this.gameObject.transform.Find("HudTextPoint"));
        hpBarSlider = hpbarGo.GetComponentInChildren<UISlider>();
        hUDText = hudTextGo.GetComponent<HUDText>();
    }
    /// <summary>
    /// 参数值：
    /// 第0个参数：按钮类型： 0 normal skill1 skill2 skill3
    /// 第1个参数：特效名字： 
    /// 第2个参数：声音名字
    /// 第3个参数：前移的距离
    /// 第4个参数：跳跃的高度
    /// </summary>
    /// <param name="args"></param>
    public void Attack(string args)
    {

        string[] proArray = args.Split(',');
        string posType = proArray[0];
        string effectName = proArray[1];
        string soundName = proArray[2];
        float moveforward = float.Parse(proArray[3]);
        float jumpHeight = float.Parse(proArray[4]);


        object[] arg = new object[3];
        AudioController.Instance.PlayEffect(soundName);
        ShowEffect(effectName);
        MoveForward(moveforward);
        JumpHeight(jumpHeight);

        if (posType== "normal")
        {
            enemyList = GetEnemyInAttackRange(AttackRange.Forward);
            foreach (var item in enemyList)
            {
                arg[0] = damageArray[1];
                arg[1] = moveforward;
                arg[2] = jumpHeight;
                item.SendMessage("TakeDamage", arg, SendMessageOptions.DontRequireReceiver);
            }
        }
        else if ( posType == "skill3")
        {
            enemyList = GetEnemyInAttackRange(AttackRange.Forward);
            foreach (var item in enemyList)
            {
                arg[0] = damageArray[3];
                arg[1] = moveforward;
                arg[2] = jumpHeight;
                item.SendMessage("TakeDamage", arg, SendMessageOptions.DontRequireReceiver);
            }
        }
        else  
        {
            int index =int.Parse( posType.Substring(posType.Length-1, 1));
            enemyList = GetEnemyInAttackRange(AttackRange.Around);
            foreach (var item in enemyList)
            {
                arg[0] = damageArray[index];
                arg[1] = moveforward;
                arg[2] = jumpHeight;
                item.SendMessage("TakeDamage", arg,SendMessageOptions.DontRequireReceiver);
            }
        }
       
        
        
 
    }
  
 

    public void ShowEffect(string effectName)
    {
        PlayerEffect pe = null;
        effectDic.TryGetValue(effectName, out pe);
        if (pe != null)
        {
            pe.ShowEffect();
        }
    }
    private void MoveForward(float moveforward)
    {
  

        iTween.MoveBy(this.gameObject, Vector3.forward * moveforward * 10000f, 0.3f);
    }
    private void JumpHeight(float jumpHeight)
    {

    }

    /// <summary>
    /// 得到攻击范围内的敌人
    /// </summary>
    /// <returns></returns>
    List<GameObject> GetEnemyInAttackRange(AttackRange attackRange)
    {

        List<GameObject> enemy = new List<GameObject>();
        switch (attackRange)
        {//查找前方的敌人
            case AttackRange.Forward:
                foreach (var item in TranscriptController.Instance.enemyList)
                {
                    Vector3 pos = transform.InverseTransformPoint(item.transform.position);

                    if (pos.z > -0.5f && Vector3.Distance(item.transform.position, transform.position) <= attackDistanceForward)
                    {

                        enemy.Add(item);
                    }
                }


                break;
            //查找周围的敌人
            case AttackRange.Around:
                foreach (var item in TranscriptController.Instance.enemyList)
                {
                    if (Vector3.Distance(item.transform.position, transform.position) <= attackDistanceAround)
                    {
                        enemy.Add(item);
                    }
                }

                break;
            default:
                break;
        }



        return enemy;
    }
    public void ShowEffectDevilHand()
    {

        string effectName = "DevilHandMobile";
        PlayerEffect playerEffect = null;
        effectDic.TryGetValue(effectName, out playerEffect);
        if (playerEffect!=null)
        {
            foreach (var item in enemyList)
            {
         GameObject go=    Instantiate<GameObject>(playerEffect.gameObject, item.transform.position, Quaternion.identity);
                go.GetComponent<PlayerEffect>().ShowEffect();
            }


        }


    }
    public void Damage(int  damage)
    {
        if (hp<=0)
        {
            return;
        }
        hp -= damage;


        //受伤动画
        int random = Random.Range(0, 100);
       
            anim.SetTrigger("TakeDamage");

            hUDText.Add(damage, Color.red, 0.3F);
        hpBarSlider.value = (float)hp / hpTotal;
        BloodScreen.Instance.ShowBloodScreen();
        if (hp<=0)
        {
            Dead();
        }
    }

    private void Dead()
    {
        Destroy(this.gameObject);
        WindowUIMgr.Instance.OpenWindow(WindowUIType.BattleOverPanel, GameObject.Find("UI Root").transform);
    }
}
