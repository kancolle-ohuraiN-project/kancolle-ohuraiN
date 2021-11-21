using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caidan_video : MonoBehaviour
{
    public GameObject caidanvideo;
    public GameObject BGM;  
    public GameObject mainUI;
    public KeyCode curinput = KeyCode.None;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetKeyDown(KeyCode.N)){
        Debug.Log("N");
      }
      
        if(Input.GetKeyDown(KeyCode.N)){
            caidanvideo.SetActive(true);
            mainUI.SetActive(false);
            BGM.SetActive(false);
        }
        if(Input.GetKeyDown(KeyCode.Escape)){
            caidanvideo.SetActive(false);
            mainUI.SetActive(true);
            BGM.SetActive(true);
        }
    }
}
