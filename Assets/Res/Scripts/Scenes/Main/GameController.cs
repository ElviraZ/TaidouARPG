using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="level"></param>
    /// <returns></returns>
    public static int GetRequiredExpByLevel(int level)
    {
        return (level-1)*(100 + (100 + 10 * (level - 2)) / 2);
    }
}
