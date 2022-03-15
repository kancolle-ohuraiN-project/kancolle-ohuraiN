using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;
public class LeftButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler 
{
  [Header("未悬停显示的对象")]
  public GameObject[] obj;
  [Header("悬停显示的对象")]
  public GameObject[] obj1;
  [Header("是否悬停")]
  public bool isOn;
  private void Update() {
    if(isOn == true){
		for (int j = 0; j < obj.Length; j++) 
		{
			if (obj[j] != null) 
			{
        obj[j].SetActive(false);
			}
		}
    for (int j = 0; j < obj1.Length; j++) 
		{
			if (obj1[j] != null) 
			{
        obj1[j].SetActive(true);
			}
		}
    }
        if(isOn == false){
		for (int j = 0; j < obj1.Length; j++) 
		{
			if (obj1[j] != null) 
			{
        obj1[j].SetActive(false);
			}
		}
    for (int j = 0; j < obj.Length; j++) 
		{
			if (obj[j] != null) 
			{
        obj[j].SetActive(true);
			}
		}
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