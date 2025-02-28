using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneFader : MonoBehaviour
{
    public Image blackimage;
    [SerializeField] private float alpha;

    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void FadeTo(string _scenename)
    {
        StartCoroutine(Fadeout(_scenename));
    }

    // Update is called once per frame
    private IEnumerator FadeIn()
    {
        alpha = 1;
        while (alpha > 0)
        {
            alpha -= Time.deltaTime;
            blackimage.color = new Color(0, 0, 0, alpha);
            yield return new WaitForSeconds(0);
        }
    }

    private IEnumerator Fadeout(string sceneName)
    {
        alpha = 0;
        while (alpha < 1)
        {
            alpha += Time.deltaTime;
            blackimage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
        SceneManager.LoadScene(sceneName);
    }
}