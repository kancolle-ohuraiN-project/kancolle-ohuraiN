using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimeKcSound : MonoBehaviour 
{
	[Header("音频列表")]
	public AudioClip[] audios;

  private int TimeKey;
  private int hour;
  private int minute;
  private int Second;


  void Update()
  {
      hour = DateTime.Now.Hour;
      minute = DateTime.Now.Minute;
      Second = DateTime.Now.Second;

      if(minute == 00 && Second == 00){
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





























