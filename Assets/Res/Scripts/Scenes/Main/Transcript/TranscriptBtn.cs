using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// 副本类
/// </summary>
public class TranscriptBtn : MonoBehaviour {


    public int id;
    public void OnClick()
    {

        transform.parent.SendMessage("TranscriptBtnClick", id);

    }
}
