using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CurrrentTime : MonoBehaviour
{
    private Text CurrrentTimeText;

    [Header("是否是显示月/日")]
    public bool isday;

    // Start is called before the first frame update
    private void Start()
    {
        CurrrentTimeText = GetComponent<Text>();
        //使用协程来进行监听，防止浪费资源
        StartCoroutine(Time());
    }

    // Update is called once per frame
    private IEnumerator Time()
    {
        if (isday == true)
        {
            CurrrentTimeText.text = string.Format("{0}", DateTime.Now.ToString("MM/dd"));
        }
        else
        {
            CurrrentTimeText.text = string.Format("{0}", DateTime.Now.ToString("HH:mm"));
        }
        //每30秒检测一次
        yield return new WaitForSeconds(30f);
    }
}