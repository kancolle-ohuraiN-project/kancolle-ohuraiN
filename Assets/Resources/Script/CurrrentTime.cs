using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CurrrentTime : MonoBehaviour
{
    private Text CurrrentTimeText;

    [Header("是否是显示月/日")]
    public bool isday;
    // Start is called before the first frame update
    void Start()
    {
        CurrrentTimeText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isday == true){
          CurrrentTimeText.text = string.Format("{0}",DateTime.Now.ToString("MM/dd"));
        }else{
          CurrrentTimeText.text = string.Format("{0}",DateTime.Now.ToString("HH:mm"));
        }
        
    }
}
