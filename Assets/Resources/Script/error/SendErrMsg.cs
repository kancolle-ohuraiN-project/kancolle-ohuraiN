using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class SendErrMsg : MonoBehaviour
{
    /*******************
     * 
     * 使用前请阅读此文档
     * https://colle.sakurakoyi.top/docs/kancolle-ohuraiN/%E9%94%99%E8%AF%AF%E5%8F%82%E6%95%B0%E4%BB%A3%E7%A0%81
     * 
     * *****************/
    public static SendErrMsg Instance { get; private set; }
    public double param { get; set; } = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
