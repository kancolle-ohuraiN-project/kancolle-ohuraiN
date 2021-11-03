using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class qwq : MonoBehaviour
{
  [Header("跳转到的场景名")]
  public string SceneName;

    // Start is called before the first frame update
    void Update()
    {
      if(Input.GetKeyDown(KeyCode.Space)){
          Debug.Log("qwq");
          SceneManager.LoadScene(SceneName);
      }
    }
}
