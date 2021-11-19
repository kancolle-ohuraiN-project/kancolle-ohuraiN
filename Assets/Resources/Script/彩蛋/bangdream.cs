using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bangdream : MonoBehaviour
{
    public GameObject nicovideo;
    public GameObject BGM;  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetKeyDown(KeyCode.B)){
        Debug.Log("B");
      }
      
        if(Input.GetKeyDown(KeyCode.B)){
            nicovideo.SetActive(true);
            BGM.SetActive(false);
        }
        if(Input.GetKeyDown(KeyCode.Escape)){
            nicovideo.SetActive(false);
            BGM.SetActive(true);
        }
    }
}
