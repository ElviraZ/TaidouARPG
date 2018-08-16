using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipPanel : SingletonMono<TipPanel> {

public    UILabel label;

    public override void Awake()
    {
        base.Awake();
        label = transform.Find("Label").GetComponent<UILabel>();
    }
    public void ShowLabelTip(string  str)
    {
        label.text = str;
        Destroy(this.gameObject, 1f);
    }
	

}
