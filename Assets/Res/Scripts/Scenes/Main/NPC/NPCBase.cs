using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBase : SingletonMono<NPCBase> {
    protected int id;
    public string desString;
    public string spriteIconStr;
    GameObject dialogPanel=null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == Tags.Player)
        {
            dialogPanel = WindowUIMgr.Instance.OpenWindow(WindowUIType.NPCDialogPanel, GameObject.Find("UI Root").transform);
            dialogPanel.GetComponent<NPCDialogPanel>().Init(id, desString, spriteIconStr);
        }


    }

    private void OnTriggerExit(Collider other)
    {
        if (dialogPanel.gameObject!=null)
        {
            dialogPanel.GetComponent<NPCDialogPanel>().OutTrigger();
        }
    }


}
