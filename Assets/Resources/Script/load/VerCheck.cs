using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using TMPro;
//证书验证问题修复
public class CertHandler : CertificateHandler
{
    protected override bool ValidateCertificate(byte[] certificateData)
    {
        return true;
    }
}
public class VerCheck : MonoBehaviour
{
    [Header("版本文件链接")]
    public string VerUrl;
    [Header("跳转到的场景名称")]
    public string ToSence;
    [Header("获取错误后跳转到的场景名称")]
    public string errorToSence;
    [Header("相关版本信息打印显示的控件")]
    public GameObject VerText;
    void Start()
    {
        Debug.Log("Start to get Ver info");
        //判断客户端是否联网
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            Debug.LogError("Not Ine");
            SendErrMsg.Instance.param = 1.2;
            SceneManager.LoadScene(errorToSence);
        }
        StartCoroutine(Get());
    }
    IEnumerator Get()
    {
        UnityWebRequest webRequest = UnityWebRequest.Get(VerUrl);
        webRequest.certificateHandler = new CertHandler();
        string clientVer = Application.version;
        //防止客户端版本获取失败
        if (clientVer == null)
        {
            SendErrMsg.Instance.param = 2.1;
            SceneManager.LoadScene(errorToSence);
        }
        //将版本信息打印到屏幕
        VerText.GetComponent<TMP_Text>().text = $"clientVer: {clientVer}\nserverVer: Geting";
        yield return webRequest.SendWebRequest();
        //异常处理
        if (webRequest.result == UnityWebRequest.Result.Success)
        {
            if (webRequest.error == null)
            {
                string serverVer = webRequest.downloadHandler.text;
                serverVer = serverVer.Replace("\n", "");
                Debug.Log("Version of the runtime: " + clientVer);
                Debug.Log("Server Get version: " + serverVer);
                if (serverVer == clientVer)
                {
                    VerText.GetComponent<TMP_Text>().text = $"clientVer: {clientVer}\nserverVer: {serverVer}";
                    //防止获取过快导致语音没播放完毕就直接跳转
                    Invoke("toscene", 5);
                }
                else
                {
                    //因为客户端与服务端(github)中的版本信息不同，以确保bug修复所跳猫
                    Debug.LogError("Version mismatch: server:" + serverVer + "|client:" + clientVer);
                    //设置错误问题传参到error场景
                    SendErrMsg.Instance.param = 2.2;
                    SceneManager.LoadScene(errorToSence);
                }
            }
            else
            {
                //因为服务端无法进行通讯所以只进行警告，但跳猫
                Debug.LogWarning("Success to get but have some problem: " + webRequest.error);
                SendErrMsg.Instance.param = 1.1;
                SceneManager.LoadScene(errorToSence);
            }
        }
        else
        {
            //获取版本信息失败，直接跳猫
            Debug.LogError("Get ver fail: " + webRequest.error);
            SceneManager.LoadScene(errorToSence);
        }
    }
    public void toscene()
    {
        SceneManager.LoadScene(ToSence);
    }
    // Update is called once per frame
    //void Update() { }
}