using UnityEngine;
using UnityEngine.SceneManagement;

public class ToScene : MonoBehaviour
{
    [Header("��ת���ĳ�����")]
    public string SceneName;

    public void GoToScene()
    {
        SceneManager.LoadScene(SceneName); //�л�Ϊ����
    }
}