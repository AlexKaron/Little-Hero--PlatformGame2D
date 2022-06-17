using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove2 : MonoBehaviour
{
    
    [SerializeField] float speed =1f;
    
    
     void Update()
    
    {
        transform.position = new Vector3(transform.position.x,Mathf.PingPong(Time.time,3), transform.position.z);
    }

    
}
