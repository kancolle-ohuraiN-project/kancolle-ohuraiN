using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Fadebutton : MonoBehaviour{
    public string scenename;//scenename这一栏的参数处写场景2的名字

    public void open()
    {
            FindObjectOfType<SceneFader1>().FadeTo(scenename);

            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);//跳到下一个场景（原场景编号+！）//这是另一种切换场景的写法
        }
}
