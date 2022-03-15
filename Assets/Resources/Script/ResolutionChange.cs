using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ResolutionChange : MonoBehaviour
{

    // Use this for initialization
    void Start () {
       //指定游戏1200x720分辨率打开游戏
       Screen.SetResolution(1200, 720, false);
    }

    // Update is called once per frame
    void Update () {

    }
}
