using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimingSwitching : MonoBehaviour
{
  [Header("跳转等待时间")]
  public int seconds;


  [Header("跳转到的场景名")]
  public string SceneName;

  [Header("是否场景加载完后直接运行")]
  public bool onStart;
    // Start is called before the first frame update
    void Start()
    {
      if(onStart == true){
        //场景运行时直接定时运行
        Invoke("toerror", seconds);
      }
    }
    public void toerror()
    {
      SceneManager.LoadScene(SceneName);
    }

}
