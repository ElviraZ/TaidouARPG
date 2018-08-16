using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Random = UnityEngine.Random;

public class EnemyBase : SingletonMono<EnemyBase>
{

    Transform player;
    Animation anim;


    protected int hpTotal;
    protected int hp = 200;

    protected float speed = 0.5f;
    protected float downSpeed = 0.5f;
    protected float attackRate = 2f;//几秒攻击一次
    protected float attackTimer = 0f;
    protected float attackDistance = 3f;
    private float distance = 0f;
    private float downdistance = 0f;
    protected int damage = 20;//怪物攻击力
    CharacterController cc;
    Transform bloodPoint;
    protected GameObject hpbarGo;
    protected UISlider hpBarSlider;
    protected GameObject hudTextGo;
    protected HUDText hUDText;


    private EnemyTrigger enemyTrigger;
    public override void Awake()
    {
        base.Awake();
        TranscriptController.Instance.AddEnemy(this.gameObject);
        hpTotal = hp;
        anim = GetComponent<Animation>();

        cc = GetComponent<CharacterController>();



        InvokeRepeating("CalcDistance", 0f, 0.1f);
    }

    public void Init(EnemyTrigger trigger)
    {
        this.enemyTrigger = trigger;
    }

    private void Start()
    {

        player = TranscriptController.Instance.playerAnimation.transform;
        bloodPoint = transform.Find("BloodPoint");
        hpbarGo = HpBarManager.Instance.GetHpBar(this.gameObject.transform.Find("HpBarPoint"));
        hudTextGo = HpBarManager.Instance.GetHudText(this.gameObject.transform.Find("HudTextPoint"));
        hpBarSlider = hpbarGo.GetComponentInChildren<UISlider>();
        hUDText = hudTextGo.GetComponent<HUDText>();
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

    }

    public virtual void Dead()
    {
        Destroy(hpbarGo);
        Destroy(hudTextGo);
        this.GetComponent<CharacterController>().enabled = false;
        int random = Random.Range(0, 10);
        if (random <= 7)
        {
            //死亡方式1  死亡动画
            anim.CrossFade("die");
   
        }
        else
        {
            //死亡方式2  破碎

            this.GetComponentInChildren<MeshExploder>().Explode();
            this.GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;

        }
         enemyTrigger.EnemyDead();
        TranscriptController.Instance.RemoveEnemy(this.gameObject);
    }


    private void Update()
    {
        if (player == null)
        {
            return;
        }
        if (hp <= 0)
        {
            downdistance += transform.up.y * downSpeed * Time.deltaTime;
            transform.Translate(-transform.up * downSpeed * Time.deltaTime);
            if (downdistance >= 4f)
            {
                Destroy(this.gameObject);
            }
            return;
        }
        if (distance <= attackDistance)
        {
            attackTimer += Time.deltaTime;
            if (attackTimer >= attackRate)
            {
                attackTimer = 0;
                anim.CrossFade("attack01");
            }
            if (!anim.IsPlaying("attack01"))
            {
                anim.CrossFade("idle");
            }
        }
        else
        {
            anim.CrossFade("walk");
            Move();
        }

    }



    public void Move()
    {

        UnityHelper.GetInstance().FaceToGoal(this.transform, player, 20f);
        cc.SimpleMove(transform.forward * speed);


    }


    public void CalcDistance()
    {
        if (player == null)
        {
            return;
        }
        distance = Vector3.Distance(player.position, this.transform.position);
    }

    public void Attack()
    {

        if (player == null)
        {
            return;
        }
        float distance = Vector3.Distance(player.transform.position, this.transform.position);
        if (distance <= attackDistance)
        {

            player.gameObject.SendMessage("Damage", damage, SendMessageOptions.DontRequireReceiver);

        }
    }
}
