using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 15f;
    Rigidbody2D rigidbody;
    PlayerMove player;
    float xSpeed;

    void Start()
    {
        rigidbody=GetComponent<Rigidbody2D>();
        player=FindObjectOfType<PlayerMove>();
        xSpeed = player.transform.localScale.x * bulletSpeed;
    }

    void Update()
    {
        rigidbody.velocity = new Vector2 (xSpeed,0f);
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
        Destroy(gameObject);
    }

    void OnCollisionEnter2D (Collision2D other)
    {
        Destroy(gameObject);
    }
}
