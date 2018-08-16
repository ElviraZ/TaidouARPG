using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UILoading : MonoBehaviour {


    AsyncOperation async;



    public Image m_pProgress;
    private int progress = 0;
    // Use this for initialization
    void Start()
    {
        StartCoroutine(LoadScenes());
    }
    IEnumerator LoadScenes()
    {
        int nDisPlayProgress = 0;
        async = SceneManager.LoadSceneAsync(GameDatas.NextSceneName);
        async.allowSceneActivation = false;
        while (async.progress < 0.9f)
        {
            progress = (int)async.progress * 100;
            while (nDisPlayProgress < progress)
            {
                ++nDisPlayProgress;
                m_pProgress.fillAmount = (float)nDisPlayProgress / 100;
                yield return new WaitForEndOfFrame();
            }
            yield return null;
        }
        progress = 100;
        while (nDisPlayProgress < progress)
        {
            ++nDisPlayProgress;
            m_pProgress.fillAmount = (float)nDisPlayProgress / 100;
            yield return new WaitForEndOfFrame();
        }
        async.allowSceneActivation = true;
  
    }
}
