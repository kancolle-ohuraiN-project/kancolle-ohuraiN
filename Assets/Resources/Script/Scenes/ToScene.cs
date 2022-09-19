using UnityEngine;
using UnityEngine.SceneManagement;

public class ToScene : MonoBehaviour
{
    [Header("跳转到的场景名")]
    public string SceneName;

    public void GoToScene()
    {
        SceneManager.LoadScene(SceneName); //切换为场景
    }
}