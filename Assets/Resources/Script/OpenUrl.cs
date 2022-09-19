using UnityEngine;

public class OpenUrl : MonoBehaviour
{
    public string url;

    public void OpenURL()
    {
        Application.OpenURL(url);
    }
}