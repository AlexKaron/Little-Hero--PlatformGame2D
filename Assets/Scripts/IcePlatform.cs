using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcePlatform : MonoBehaviour
{
    [SerializeField] AudioClip iceSFX;
   void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(iceSFX, Camera.main.transform.position);
            Destroy(gameObject);
        }
    }
}
