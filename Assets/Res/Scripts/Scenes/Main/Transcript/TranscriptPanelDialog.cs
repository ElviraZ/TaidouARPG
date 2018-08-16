using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TranscriptPanelDialog :UIBase {


    UILabel title;
    UILabel desLabel;
    UILabel energyLabel;
  public  string nextSceneName;
    Transcript temp = null;
    public override void Awake()
    {
        base.Awake();

        title = transform.Find("bg/Title").GetComponent<UILabel>();
        desLabel = transform.Find("bg/DesLabel").GetComponent<UILabel>();

        energyLabel = transform.Find("bg/EnergyLabel").GetComponent<UILabel>();
      

    }

    public void Init(int id)
    {
         temp = TranscriptManager.Instance.GetTranscriptById(id);
        title.text = temp.Name;
        desLabel.text = temp.Des;
        energyLabel.text = temp.EnergyCost;
        nextSceneName = temp.SceneName;

    }

    public override void OnBtnClick(GameObject go)
    {
        base.OnBtnClick(go);
        switch (go.name)
        {
            case "BtnEnter":
                BtnEnterClick();

                break;
            case "BtnClose":
                BtnCloseClick();

                break;
            default:
                break;
        }
    }

    private void BtnCloseClick()
    {
        Close();
        nextOpenWindow = WindowUIType.Hide;
    }

    private void BtnEnterClick()
    {
   
        Close();
      GameDatas.NextSceneName = "3transcript";
     //   GameDatas.NextSceneName = nextSceneName.Replace(" ","");
        SceneManager.LoadScene("0Loading");


    }
}
