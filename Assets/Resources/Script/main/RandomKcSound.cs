using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class RandomKcSound : MonoBehaviour
{
	[Header("音频列表")]
	public AudioClip[] audios;
	public GameObject kansen;
	// Start is called before the first frame update
	public void RandomSound()
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
		int RandKey = Random.Range(0, n);
		//控制播放
		this.GetComponent<AudioSource>().clip = audios[RandKey];
		this.GetComponent<AudioSource>().Play();
		//播放点击动画
        kansen.GetComponent<Animator>().enabled = true;
        kansen.GetComponent<Animator>().Play("舰娘点击",-1,0f);
    }
}