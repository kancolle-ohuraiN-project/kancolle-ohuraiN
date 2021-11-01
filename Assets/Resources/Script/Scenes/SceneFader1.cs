using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader1 : MonoBehaviour
{
    public Image blackimage;
    [SerializeField] private float alpha; //这里调用了自动调节alpha值的一个方法

    private void Start()
    {
      
    }
    public void FadeTo(string _scenename)
    {
        StartCoroutine(Fadeout(_scenename));//具体代码在下方
    }

    // Update is called once per frame
   
    IEnumerator Fadeout(string sceneName)
    {
        alpha = 0;
        while (alpha < 1)
        {
            alpha += Time.deltaTime;
            blackimage.color = new Color(0, 0, 0, alpha);
            yield return null;

        }

        //这里我事先设置了blackimage alpha为0，而上述的触发机制是以场景2为依据，场景2 的跳转需要实现player和 exit的trigger ，所以淡出动画非自动，就算alpha为0，也需要条件触发


        SceneManager.LoadScene(sceneName);//切换为场景2
    }

}