using UnityEngine;

public class Fadebutton : MonoBehaviour
{
    [Header("跳转到的场景名")]
    public string scenename;//scenename这一栏的参数处写场景2的名字

    public void open()
    {
        FindObjectOfType<SceneFader1>().FadeTo(scenename);

        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);//跳到下一个场景（原场景编号+！）//这是另一种切换场景的写法
    }
}