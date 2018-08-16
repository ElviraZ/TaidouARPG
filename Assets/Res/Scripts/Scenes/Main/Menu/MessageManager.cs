using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageManager : SingletonMono<MessageManager>
{
    UILabel label;
    TweenAlpha tweenAlpha;

    public override void Awake()
    {
        base.Awake();
        label = transform.Find("Label").GetComponent<UILabel>();
        tweenAlpha = GetComponent<TweenAlpha>();
        this.gameObject.SetActive(false);
    }
    public void  SetMessage(string  str)
    {
        StopAllCoroutines();
        this.gameObject.SetActive(true);
        tweenAlpha.PlayForward();
  
        label.text = str;
        float timer = tweenAlpha.duration;
        StartCoroutine("Show",timer);

    }


    IEnumerator Show(float timer)
    {
        yield return new WaitForSeconds(timer);
        tweenAlpha.PlayReverse();
        yield return new WaitForSeconds(timer);
        this.gameObject.SetActive(false);
    }
}
