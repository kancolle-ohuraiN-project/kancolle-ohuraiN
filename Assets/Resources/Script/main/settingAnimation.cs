using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class settingAnimation : MonoBehaviour 
{
	[Header("动画的组件")]
	public GameObject gaminitor;
  public GameObject BG;
  public Animator B_Animator;
	[Header("是否已经打开")]
	public int isopen = 0;
	Animator m_Animator;
	void Start() 
	{
    B_Animator = BG.GetComponent<Animator>();
		m_Animator = gameObject.GetComponent<Animator>();
		m_Animator.SetBool("isclose", false);
    B_Animator.SetBool("isclose", false);
	}
	public void OnClick()
	{
		if(isopen == 0) 
		{
      m_Animator.SetBool("isclose", false);
      B_Animator.SetBool("isclose", false);
			gaminitor.GetComponent<Animator>().enabled = true;
      BG.GetComponent<Animator>().enabled = true;
			isopen = 1;
		} else 
		{
      m_Animator.SetBool("isclose", true);
      B_Animator.SetBool("isclose", true);
			isopen = 0;
		}
	}
}