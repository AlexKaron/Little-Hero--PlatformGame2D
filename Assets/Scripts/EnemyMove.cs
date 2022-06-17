using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] float enemySpeed = 5f;
    Rigidbody2D rigidbody;
    
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        rigidbody.velocity = new Vector2 (enemySpeed, 0f);
    }

    void OnTriggerExit2D (Collider2D other)
    {
        enemySpeed = -enemySpeed;
        FlipEnemy();
    }

    void FlipEnemy()
    {
        transform.localScale = new Vector2 (-(Mathf.Sign(rigidbody.velocity.x)),1f);
    }
}
