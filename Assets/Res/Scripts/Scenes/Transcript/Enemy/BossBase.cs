using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Random = UnityEngine.Random;

public class BossBase : SingletonMono<BossBase>
{

    protected float viewAngle = 50;//视角范围
    float rotateSpeed = 3;
    float moveSpeed = 2;
    float attackTimer = 0;

    private float timeInterval = 1f;//攻击的时间间隔

    private bool isAttacking = false;
    protected float attackDistance = 4f;

    private Transform playerTF;
    private Animation anim;

    private GameObject attack01, attack02, attack03;
    private int[] attackDamage = new int[3] { 20, 30, 40 };
    protected int hpTotal;
    protected int hp = 2000;
    Transform bloodPoint;
    protected GameObject hpbarGo;
    protected UISlider hpBarSlider;
    protected GameObject hudTextGo;
    protected HUDText hUDText;

    public void Start()
    {

        playerTF = TranscriptController.Instance.playerAnimation.gameObject.transform;
        anim = GetComponent<Animation>();
        attack01 = transform.Find("attack01").gameObject;
        attack02 = transform.Find("attack02").gameObject;
        attack03 = transform.Find("attack03").gameObject;

        bloodPoint = transform.Find("BloodPoint");
        hpbarGo = HpBarManager.Instance.GetHpBar(this.gameObject.transform.Find("HpBarPoint"));
        hudTextGo = HpBarManager.Instance.GetHudText(this.gameObject.transform.Find("HudTextPoint"));
        hpBarSlider = hpbarGo.GetComponentInChildren<UISlider>();
        hUDText = hudTextGo.GetComponent<HUDText>();
    }



    private void Update()
    {
        if (playerTF==null)
        {
            return;
        }
        //计算同平面上的夹角
        Vector3 playerPos = playerTF.position;
        playerPos.y = transform.position.y;

        float angle = Vector3.Angle(playerPos - transform.position, transform.forward);
        if (angle <= viewAngle)
        {
            float distance = Vector3.Distance(playerPos, transform.position);
            if (distance <= attackDistance)
            {
                UnityHelper.GetInstance().FaceToGoal(this.transform, playerTF, rotateSpeed );
                if (isAttacking == false)
                {
                    anim.CrossFade("idle");
                    attackTimer += Time.deltaTime;
                    if (attackTimer >= timeInterval)
                    {
                        //攻击
                        Attack();
                        attackTimer = 0f;
                    }
                }

            }
            else
            {
                //追击
                Pursure();


            }
        }
        else
        {
            //视野之外转向
        
            UnityHelper.GetInstance().FaceToGoal(this.transform, playerTF, rotateSpeed);

        }
    }


    /// <summary>
    /// Boss 的追击
    /// </summary>
    private void Pursure()
    {
        isAttacking = false;
        anim.CrossFade("walk");
        this.GetComponent<Rigidbody>().MovePosition(transform.position + transform.forward * moveSpeed * Time.deltaTime);
    }
    /// <summary>
    /// Boss 的攻击
    /// </summary>
    private void Attack()
    {
        if (playerTF == null)
        {
            return;
        }
        isAttacking = true;
        int ran = Random.Range(1, 4);

        anim.CrossFade("attack0" + ran.ToString());

    }
    public void Attack01()
    {
        if (playerTF == null)
        {
            return;
        }
        attack01.SetActive(true);
        if (Vector3.Distance(playerTF.position,this.transform.position)<=attackDistance)
        {
            playerTF.gameObject.SendMessage("Damage", attackDamage[0]);
        }
}
    public void Attack02()
    {
        if (playerTF == null)
        {
            return;
        }
        attack02.SetActive(true);
        if (Vector3.Distance(playerTF.position, this.transform.position) <= attackDistance)
        {
            playerTF.gameObject.SendMessage("Damage", attackDamage[1]);
        }
    }
    public void Attack03()
    {
        if (playerTF == null)
        {
            return;
        }
        attack01.SetActive(true);
        if (Vector3.Distance(playerTF.position, this.transform.position) <= attackDistance)
        {
            playerTF.gameObject.SendMessage("Damage", attackDamage[2]);
        }
    }

    public void BackToStand()
    {
        isAttacking = false;
    }

    /// <summary>
    /// 0、受到的攻击
    /// 1、收到的伤害
    /// 2、浮空或者后退的距离
    /// </summary>
    public void TakeDamage(object[] arg)
    {
        if (hp <= 0)
        {
            return;
        }

        StopAllCoroutines();
        Combo.Instance.ComboPlus();
        int damage = (int)arg[0];
        float moveforward = (float)arg[1];
        float jumpHeight = (float)arg[2];

        anim.CrossFade("takedamage");

        iTween.MoveBy(this.gameObject, transform.InverseTransformDirection(TranscriptController.Instance.playerAnimation.transform.forward) * moveforward + Vector3.up * jumpHeight, 0.3f);
        GameObject effect = Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/EffectPrefabs/BloodSplatEffect"), bloodPoint.position, Quaternion.identity);
        hp -= damage;
        if (hp <= 0)
        {
            Dead();
        }
        hpBarSlider.value = (float)hp / hpTotal;
        hUDText.Add(damage, Color.red, 0.3F);
        StartCoroutine("PursurePlayer");

    }

    IEnumerator PursurePlayer()
    {
        yield return new WaitForSeconds(1f);
        //Pursure();
        Attack();
    }
    public virtual void Dead()
    {
        Destroy(hpbarGo);
        Destroy(hudTextGo);
        anim.CrossFade("die");
        TranscriptController.Instance.RemoveEnemy(this.gameObject);
        WindowUIMgr.Instance.OpenWindow(WindowUIType.BattleOverPanel, GameObject.Find("UI Root").transform);
    }
}
