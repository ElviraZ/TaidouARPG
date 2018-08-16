
using UnityEngine;
using System.Collections;

/// <summary>
/// 
/// </summary>
public static class StringUtil 
{
    /// <summary>
    /// string转成int
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static int ToInt(this string str)
    {
        int temp = 0;
        int.TryParse(str, out temp);
        return temp;
    }
    /// <summary>
    /// string转成float
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static float ToFloat(this string str)
    {
        float temp = 0;
        float.TryParse(str, out temp);
        return temp;
    }
}