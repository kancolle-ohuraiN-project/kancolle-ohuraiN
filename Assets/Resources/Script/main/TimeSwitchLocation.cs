using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TimeSwitchLocation : MonoBehaviour
{
    private int hour;
    private int TimeKey;
    public Sprite[] TextureList;

    [SerializeField]
    private Image myImage;

    private void Start()
    {
        //使用协程来进行监听，防止浪费资源
        StartCoroutine(Time());
    }

    // Update is called once per frame
    private IEnumerator Time()
    {
        hour = DateTime.Now.Hour;
        if (6 <= hour && hour < 10)
        {
            TimeKey = 0;
        }
        else if (10 <= hour && hour < 17)
        {
            TimeKey = 1;
        }
        else if (17 <= hour && hour < 19)
        {
            TimeKey = 2;
        }
        else if (19 <= hour && hour < 21)
        {
            TimeKey = 3;
        }
        else if (21 <= hour && hour < 2)
        {
            TimeKey = 4;
        }
        else
        {
            TimeKey = 3;
        }
        myImage.sprite = TextureList[TimeKey];
        //第一次判断后每5分钟检测一次
        yield return new WaitForSeconds(300f);
    }
}