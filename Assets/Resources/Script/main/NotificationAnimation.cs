using UnityEngine;

public class NotificationAnimation : MonoBehaviour
{
    [Header("动画的组件")]
    public GameObject gaminitor;

    [Header("是否已经打开")]
    public int isopen = 0;

    private Animator m_Animator;

    private void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
        m_Animator.SetBool("isclose", false);
    }

    public void OnClick()
    {
        //控制是否播放开/关动画
        if (isopen == 0)
        {
            gaminitor.GetComponent<Animator>().enabled = false;
            m_Animator.SetBool("isclose", false);
            gaminitor.GetComponent<Animator>().enabled = true;
            isopen = 1;
        }
        else
        {
            m_Animator.SetBool("isclose", true);
            isopen = 0;
        }
    }
}