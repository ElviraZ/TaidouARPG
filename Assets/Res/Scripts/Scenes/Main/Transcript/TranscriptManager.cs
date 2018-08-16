using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranscriptManager : SingletonMono<TranscriptManager>
{

    public TextAsset listInfo;
    private Dictionary<int,Transcript> transcriptList = new Dictionary<int, Transcript>();
    public override void Awake()
    {
        base.Awake();
        InitTranscript();

    }

    void InitTranscript()
    {
        string str = listInfo.ToString();
        string[] itemStrArray = str.Split('\n');
        foreach (string itemStr in itemStrArray)
        {
            string[] proArray = itemStr.Split('|');
            Transcript transcript = new Transcript();
            transcript.Id = int.Parse(proArray[0]);
            transcript.Name = proArray[1];
            transcript.Des = proArray[2];
            transcript.EnergyCost = proArray[3];
            transcript.NeedLevel = int.Parse(proArray[4]);
            transcript.Goods = proArray[5];
            transcript.SceneName = proArray[6];

            transcriptList.Add(transcript.Id,transcript);
        }


    }


    public Transcript GetTranscriptById(int id)
    {
        Transcript temp = null;
        transcriptList.TryGetValue(id, out temp);

        return temp;
    }
}
