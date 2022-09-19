using UnityEngine;

//防止出现CS0104
using Random = UnityEngine.Random;

public class RandomKcSound : MonoBehaviour
{
    [Header("音频列表")]
    public AudioClip[] audios;

    public GameObject kansen;

    [Header("上一次的Key")]
    public int LastKey;

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
    //Goto语句
    ReGetKey:
        //生成随机数
        int RandKey = Random.Range(0, n);
        //防止同一语音连续触发两次
        if (RandKey == LastKey)
        {
            //使用Goto来重新生成一个Key
            //Debug.Log(RandKey);
            //Debug.Log(LastKey);
            goto ReGetKey;
        }
        //控制播放
        this.GetComponent<AudioSource>().clip = audios[RandKey];
        LastKey = RandKey;
        this.GetComponent<AudioSource>().Play();
        //播放点击动画
        kansen.GetComponent<Animator>().enabled = true;
        kansen.GetComponent<Animator>().Play("舰娘点击", -1, 0f);
    }
}