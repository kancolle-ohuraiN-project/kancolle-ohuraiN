using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;
public class LeftButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Tooltip("挂载时请关闭子组件image中的光线投射目标")]
    [Header("未悬停显示的对象")]
    public GameObject obj;
    [Tooltip("挂载时请关闭子组件image中的光线投射目标")]
    [Header("悬停显示的对象")]
    public GameObject obj1;
    [Header("是否悬停")]
    public bool isOn;
    private void Update()
    {
        if (isOn == true)
        {
            obj.SetActive(false);
            obj1.SetActive(true);
        }
        else
        {
            obj1.SetActive(false);
            obj.SetActive(true);
        }
        
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        isOn = true;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        isOn = false;
    }
}