using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
   private GameObject vector1, point;
 
    // Start is called before the first frame update
    void Start()
    {

        vector1 = GameObject.Find("Vector1");
        point = GameObject.Find("Triangle");
      
        point.transform.eulerAngles = Vector3.forward * 120;
       
        point.transform.position = Vector3.down;
        vector1.transform.localEulerAngles = Vector3.forward * 180;
        
       

    }

}


