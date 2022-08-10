using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

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

  void Start()
  {
    Debug.Log("Start to get Ver info");
    StartCoroutine(Get());
  }

  IEnumerator Get()
  {
    UnityWebRequest webRequest = UnityWebRequest.Get(VerUrl);
    webRequest.certificateHandler = new CertHandler();

    yield return webRequest.SendWebRequest();
    //异常处理
    if (webRequest.result == UnityWebRequest.Result.Success)
    {
      if (webRequest.error == null)
      {
        string serverVer = webRequest.downloadHandler.text;
        string clientVer = Application.version;
        serverVer = serverVer.Replace("\n","");
        Debug.Log("Version of the runtime: " + serverVer);
        Debug.Log("Server Get version: " + clientVer);
        if (serverVer == clientVer)
        {
          //防止获取过快导致语音没播放完毕就直接跳转
          Invoke("toscene", 5);
        }
        else
        {
          //因为客户端与服务端(github)中的版本信息不同，以确保bug修复所跳猫
          Debug.LogError("Version mismatch: server:" + serverVer + "|client:" + clientVer);
          SceneManager.LoadScene(errorToSence);
        }
      }
      else
      {
        //因为服务端无法进行通讯所以只进行警告，不跳猫
        Debug.LogWarning("Success to get but have some problem: " + webRequest.error);
        Invoke("toscene", 5);
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
