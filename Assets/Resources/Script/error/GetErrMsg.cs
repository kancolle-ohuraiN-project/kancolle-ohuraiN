using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UIElements;
public class GetErrMsg : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("错误信息文本")]
    public string ErrorText;
    void Start()
    {
        double param = SendErrMsg.Instance.param;
        string ErrorCode = param.ToString("G");
        ErrMsgJudge(ErrorCode);
    }
    private void ErrMsgJudge(string param)
    {
        
        switch (param)
        {
            case "1.1":
                ErrorText = "服务端似乎出现问题\n请联系开发者或者更换网络";
                break;
            case "1.2":
                ErrorText = "客户端处于离线状态\n为了保证服务正常，请打开网络";
                break;
            case "1.3":
                ErrorText = "从服务器中返回的信息似乎是被吞\n请重启客户端并保证网络正常";
                break;
            case "2.1":
                ErrorText = "无法获取客户端版本\n请检查是否从官方渠道下载)";
                break;
            case "2.2":
                ErrorText = "客户端版本并不为服务端版本\n请更新客户端";
                break;
            default:
                ErrorText = "我们也不知道您遇见什么错误了\n请您重启游戏试试？";
                break;
        }
        //打印字符
        this.GetComponent<TMP_Text>().text = ErrorText;
    }
}