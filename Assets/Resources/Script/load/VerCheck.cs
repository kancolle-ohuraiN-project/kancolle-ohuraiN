using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class VerCheck : MonoBehaviour
{
    [Header("版本文件链接")]
    public string VerUrl;

    [Header("跳转到的场景名称")]
    public string ToSence;

    void Start()
    {
        StartCoroutine(Get());
    }

    IEnumerator Get()
    {
        UnityWebRequest webRequest = UnityWebRequest.Get(VerUrl);

        yield return webRequest.SendWebRequest();
        //异常处理
        if (webRequest.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log(webRequest.error);
            SceneManager.LoadScene("error");
        }
        else
        {
            SceneManager.LoadScene(ToSence);
        }
    }
    // Update is called once per frame
    //void Update() { }
}
