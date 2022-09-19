using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadToError : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SendErrMsg.Instance.param = "99.99";  //设置参数
            SceneManager.LoadScene("error");  //跳转至Error
        }
    }
}