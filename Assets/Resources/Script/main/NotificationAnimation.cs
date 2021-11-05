using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class NotificationAnimation : MonoBehaviour 
{
	[Header("动画的组件")]
	public GameObject gaminitor;
	[Header("是否已经打开")]
	public int isopen = 0;
	Animator m_Animator;
	void Start() 
	{
		m_Animator = gameObject.GetComponent<Animator>();
		m_Animator.SetBool("isclose", false);
	}
	public void OnClick()
	{
		if(isopen == 0) 
		{
			Debug.Log("isClick");
      m_Animator.SetBool("isclose", false);
			gaminitor.GetComponent<Animator>().enabled = true;
			isopen = 1;
		} else 
		{
			Debug.Log("isClick");
      m_Animator.SetBool("isclose", true);
			isopen = 0;
		}
	}
}