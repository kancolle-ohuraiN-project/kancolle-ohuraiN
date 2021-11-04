using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{
  [Header("每次旋转角度")]
  public int rotation_angle = 0;
  [Header("当前旋转角度")]
  public int rotation_angle_now = 0;

  public float i = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(i >= 1){
          rotationing();
          i = 0;
        }
        i += Time.deltaTime;
    }
    public void rotationing()
    {
      rotation_angle_now = rotation_angle_now+rotation_angle;
      transform.rotation = Quaternion.Euler(new Vector3(0, 0, rotation_angle_now));
    }
}
