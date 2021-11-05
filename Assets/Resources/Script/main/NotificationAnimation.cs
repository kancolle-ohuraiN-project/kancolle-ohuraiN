using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationAnimation : MonoBehaviour
{
    [Header("动画的组件")]
    public GameObject gaminitor;//获取组件

    [Header("是否已经打开")]
    public int isopen = 0;
    public void OnClick()//定义一个点击函数
    {
      if(isopen == 0){
        Debug.Log("isClick");
        gaminitor.GetComponent<Animator>().enabled = true;// 激活动画组件
        isopen = 1;
      }else{
        Debug.Log("isClick");
        gaminitor.GetComponent<Animator>().enabled = false;// 激活动画组件
      }
        
    }
}
