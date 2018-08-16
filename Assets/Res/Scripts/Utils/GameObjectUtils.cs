using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameObjectUtils 
 {




    public static T     GetOrCreateComponent<T>(this GameObject obj)where T:MonoBehaviour
    {
        T t = obj.GetComponent<T>();
        if (t==null)
        {

            t = obj.AddComponent<T>();
        }
        return t;
    }
}
