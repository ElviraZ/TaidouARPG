using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShowSelectPanel : UIBase
{
    UIInput nameInput;

    public GameObject[] prefabs;
    public override void Awake()
    {
        base.Awake();

        nameInput = transform.Find("NameInput").GetComponent<UIInput>();

        foreach (GameObject item in prefabs)
        {
        
            item.transform.localScale = Vector3.one;
        }

   

    }
    public override void OnBtnClick(GameObject go)
    {
        base.OnBtnClick(go);
        switch (go.name)
        {
            case "btnSure":
                SureClick();
                break;

            case "btnClose":
                CloseClick();
                break;
            default:
                break;
        }
    }

    internal void Select(int thisId)
    {

        prefabs[thisId].transform.localScale = 1.2f * Vector3.one;
        prefabs[(thisId + 1) % 2].transform.localScale = Vector3.one;
        StartController.Instance.characterSelectIndex = thisId;
    }

    private void CloseClick()
    {
        Close();
        nextOpenWindow = WindowUIType.CharacterSelectPanel;
    }

    private void SureClick()
    {

        string name = nameInput.value;

        if (name!=null)
        {
            StartController.Instance.strName = name;

        }
        Close();
        nextOpenWindow = WindowUIType.CharacterSelectPanel;

    }
}
