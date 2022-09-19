using System;
using System.Collections;
using UnityEngine;

public class TimeKcSound : MonoBehaviour
{
    [Header("音频列表")]
    public AudioClip[] audios;

    private int TimeKey;
    private int hour;
    private int minute;
    private int Second;

    private void Start()
    {
        //使用协程来进行监听，防止浪费资源
        StartCoroutine(Time());
    }

    private IEnumerator Time()
    {
        //每秒检测一次
        yield return new WaitForSeconds(1f);
        hour = DateTime.Now.Hour;
        minute = DateTime.Now.Minute;
        Second = DateTime.Now.Second;

        if (minute == 00 && Second == 00)
        {
            TimeSound(hour);
        }
    }

    public void TimeSound(int TimeKey)
    {
        //控制播放
        this.GetComponent<AudioSource>().clip = audios[TimeKey];
        this.GetComponent<AudioSource>().Play();
    }
}