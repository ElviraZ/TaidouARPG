using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartController : SingletonMono<StartController> {

    public int characterSelectIndex=0;


    public string strName = string.Empty;
    public string Rolelevel = "0";
    public override void Awake()
    {
        base.Awake();



    }

 IEnumerator  Start()
    {
        yield return new WaitForSeconds(0.2f);
        WindowUIMgr.Instance.OpenWindow(WindowUIType.StartMenuPanel, this.gameObject.transform);



    }
}
