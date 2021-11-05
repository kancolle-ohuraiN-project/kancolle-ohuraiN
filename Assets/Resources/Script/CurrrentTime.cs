using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CurrrentTime : MonoBehaviour
{
    private Text CurrrentTimeText;
    private int hour;
    private int minute;
    private int month;
    private int day;

    [Header("是否是显示月/日")]
    public bool isday;
    // Start is called before the first frame update
    void Start()
    {
        CurrrentTimeText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        hour = DateTime.Now.Hour;
        minute = DateTime.Now.Minute;
        month = DateTime.Now.Month;
        day = DateTime.Now.Day;
        if(isday == true){
          CurrrentTimeText.text = string.Format("{0:D2}/{1:D2}",month,day);
        }else{
          CurrrentTimeText.text = string.Format("{0:D2}:{1:D2}",hour,minute);
        }
        
    }
}
