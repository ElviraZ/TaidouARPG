using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour {

    private int thisId;
    public int ThisId
    {
        get {
            if (this.gameObject.name.Contains("man"))
            {
                thisId = 0;
            }
            else
            {
                thisId = 1;
            }
                
            return thisId; }
        set { thisId = value; }
    }

 void   OnPress(bool isPress)
    {

        if (isPress==false)
        {
            this.gameObject.GetComponentInParent<CharacterShowSelectPanel>().Select(ThisId);
            Debug.Log(ThisId);

        }

    }
}
