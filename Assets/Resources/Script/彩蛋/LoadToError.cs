using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadToError : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SendErrMsg.Instance.param = "99.99";  //���ò���
            SceneManager.LoadScene("error");  //��ת��Error
        }
    }
}