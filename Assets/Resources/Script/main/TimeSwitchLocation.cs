using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TimeSwitchLocation : MonoBehaviour
{
    private int hour;
    private int TimeKey;
    public Sprite[] TextureList;
    [SerializeField]
    Image myImage;
    // Update is called once per frame
    void Update()
    {
        hour = DateTime.Now.Hour;
        if(6 <= hour && hour < 10){
          TimeKey = 0;
        }else if(10 <= hour && hour < 17){
          TimeKey = 1;
        }else if(17 <= hour && hour < 19){
          TimeKey = 2;
        }else if(19 <= hour && hour < 21){
          TimeKey = 3;
        }else if(21 <= hour && hour < 2){
          TimeKey = 4;
        }else{
          TimeKey = 3;
        }
        myImage.sprite = TextureList[TimeKey];
    }
}
