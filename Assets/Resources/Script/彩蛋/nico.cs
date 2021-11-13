using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nico : MonoBehaviour
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
      if(Input.GetKeyDown(KeyCode.N)){
        Debug.Log("N");
      }
      
        if(Input.GetKeyDown(KeyCode.N)){
            nicovideo.SetActive(true);
            BGM.SetActive(false);
        }
        if(Input.GetKeyDown(KeyCode.Escape)){
            nicovideo.SetActive(false);
            BGM.SetActive(true);
        }
    }
}
