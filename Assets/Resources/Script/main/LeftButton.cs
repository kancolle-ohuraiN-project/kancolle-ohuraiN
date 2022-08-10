using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;
public class LeftButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("未悬停显示的对象")]
    public GameObject obj;
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
            Debug.LogWarning(isOn);
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