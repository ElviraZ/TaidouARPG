using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectPanel : UIBase
{
    public UILabel nameLabel;
    public UILabel levelLabel;
 public   GameObject[] prefabs;
    public override void Awake()
    {
        base.Awake();

        nameLabel = transform.Find("InfoBg/NameLabel").GetComponent<UILabel>();
        levelLabel = transform.Find("InfoBg/LevelLabel").GetComponent<UILabel>();


        foreach (GameObject item in prefabs)
        {
            item.SetActive(false);
        }
        prefabs[StartController.Instance.characterSelectIndex].SetActive(true);


        nameLabel.text = StartController.Instance.strName;
        levelLabel.text = "Lv."+StartController.Instance.Rolelevel;
    }
    public override void OnBtnClick(GameObject go)
    {
        base.OnBtnClick(go);
        switch (go.name)
        {
            case "btnEnterGame":
                EnterGameClick();
                break;
            case "btnChangeRole":
                ChangeRoleClick();
                break;
            case "btnClose":
                CloseClick();
                break;
            default:
                break;
        }
    }

    private void EnterGameClick()
    {  Close();
        GameDatas.NextSceneName = "2mainmenu";
        SceneManager.LoadScene("0Loading");
      

    }

    private void ChangeRoleClick()
    {
        Close();
        nextOpenWindow = WindowUIType.CharacterShowSelectPanel ;
    }

    private void CloseClick()
    {
        Close();
        nextOpenWindow = WindowUIType.StartMenuPanel;
    }
}
