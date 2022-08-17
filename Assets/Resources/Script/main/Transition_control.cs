using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Transition_control : MonoBehaviour
{
  public GameObject A_Animator;
  public GameObject startUI;
  public GameObject endUI;

  public void TransitionControl()
  {
    A_Animator.SetActive(true);
    Invoke("TransitionControl1", 0.5f);
  }
  public void TransitionControl1()
  {
    startUI.SetActive(false);
    endUI.SetActive(true);
    Invoke("TransitionControl2", 1f);
  }
  public void TransitionControl2()
  {
    A_Animator.SetActive(false);
  }
}
