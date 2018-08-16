using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// 集成大量的通用算法
/// </summary>

    public class UnityHelper 
    {
        private static UnityHelper _Instance=null;
        private UnityHelper  ()
        {

        }
        public  static   UnityHelper  GetInstance()
        {
            if (_Instance==null)
                _Instance = new UnityHelper ();
            return _Instance;
        }
        float deltaTime;
        /// <summary>
        /// 间隔指定时间，返回bool值，true：时间到了，false，时间没到
        /// </summary>
        /// <param name="delta"></param>
        /// <returns> </returns>
        public bool    GetSmallTime(float  delta)
        {
            deltaTime += Time.deltaTime;
            if (deltaTime>=delta)
            {
                deltaTime = 0;
                return true;
            }
            else
            {
                return false; 
            }
        }
        /// <summary>
        /// 面向指定目标，sourceTransform：自身，targeTransform：目标，rotationSpeed：旋转速度
        /// </summary>
        /// <param name="targeTransform"></param>
        /// <param name="sourceTransform"></param>
        /// <param name="rotationSpeed"></param>
        public void FaceToGoal(Transform  sourceTransform,Transform   targeTransform,float rotationSpeed)
        {

            sourceTransform.rotation =
                Quaternion.Slerp(
                    sourceTransform.rotation,
                    Quaternion.LookRotation(new Vector3(targeTransform.position.x, 0, targeTransform.position.z) - new Vector3(sourceTransform.position.x, 0, sourceTransform.position.z)),
                    rotationSpeed*Time.deltaTime);
        }

       /// <summary>
       /// 返回minNum和maxNum之间的随机值，minNum：最小值，maxNum：最大值
       /// </summary>
       /// <param name="minNum"></param>
       /// <param name="maxNum"></param>
       /// <returns></returns>
        public int GetRandomNum(int minNum,int maxNum)
        {
            int random = 0;
            if (minNum==maxNum)
            {
                random = minNum;
            }
            random= Random.Range(minNum, maxNum+1);
            return random;
        }
    }

