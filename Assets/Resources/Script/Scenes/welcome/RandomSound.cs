using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RandomSound : MonoBehaviour 
{
	[Header("音频列表")]
	public AudioClip[] audios;
	// Start is called before the first frame update
	void Start() 
	{
		//获取音频数组数量
		int n = 0;
		for (int j = 0; j < audios.Length; j++) 
		{
			if (audios[j] != null) 
			{
				n++;
			}
		}
		//生成随机数
		int  RandKey= Random.Range(0, n);
		//控制播放
		this.GetComponent<AudioSource>().clip = audios[RandKey];
		this.GetComponent<AudioSource>().Play();
	}
}