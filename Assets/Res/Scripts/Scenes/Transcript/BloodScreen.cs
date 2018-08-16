using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodScreen : SingletonMono<BloodScreen>
{
    TweenAlpha tweenAlpha;
    public override void Awake()
    {
        base.Awake();
        tweenAlpha = GetComponent<TweenAlpha>();
    }
    public void ShowBloodScreen()
    {
        this.GetComponent<UISprite>().alpha = 1;
        tweenAlpha.ResetToBeginning();
        tweenAlpha.PlayForward();
    }
}
