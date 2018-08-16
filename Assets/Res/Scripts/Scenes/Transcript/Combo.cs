using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combo : SingletonMono<Combo>
{
    UILabel numLabel;
    private float timer = 0f;
    public int comboCount = 0;
    private float comboTime = 2f;
    public override void Awake()
    {
        base.Awake();
        numLabel = transform.Find("Label").GetComponent<UILabel>();
        this.gameObject.SetActive(false);
    }
    public void ComboPlus()
    {
        this.gameObject.SetActive(true);
        timer = comboTime;

        comboCount++;
        numLabel.text = comboCount.ToString();
        transform.localScale = Vector3.one;
        iTween.ScaleTo(this.gameObject, Vector3.one * 1.5f, 0.1f);
        iTween.ShakePosition(this.gameObject, new Vector3(0.2f, 0.2f, 0.2f), 0.2f);
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer<=0)
        {
            this.gameObject.SetActive(false);
            comboCount=0;
        }
    }
}
