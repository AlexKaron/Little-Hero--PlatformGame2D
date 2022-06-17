using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMove : MonoBehaviour
{
    [SerializeField] float runSpeed = 10f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] Vector2 deathEffect = new Vector2 (5f,5f);
    [SerializeField] GameObject bullet;
    [SerializeField] Transform gun;
    Vector2  moveInput;
    Rigidbody2D rigidbody;
    Animator animator;
    CapsuleCollider2D bodyCollider;
    BoxCollider2D feetCollider;

    bool alive = true;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        bodyCollider = GetComponent<CapsuleCollider2D>();
        feetCollider = GetComponent<BoxCollider2D>();

    }

    void Update()
    {
        if (!alive)
        {
            return;
        }
        Run();
        Flip();
        Die();
    }


    void OnFire(InputValue value)
    {
        if (!alive)
        {
            return;
        }
        Instantiate(bullet, gun.position, transform.rotation);
    }
    void OnMove(InputValue value)
    {
        if (!alive)
        {
            return;
        }
        moveInput = value.Get<Vector2>();
        Debug.Log(moveInput);
    }

    void OnJump (InputValue value)
    {
        if (!alive)
        {
            return;
        }
        if (!feetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            return;
        }

        if(value.isPressed)
        {
            rigidbody.velocity += new Vector2 (0f, jumpSpeed);
        }
    }

    void Run()
    {
        Vector2 playerVelocity = new Vector2 (moveInput.x * runSpeed, rigidbody.velocity.y);
        rigidbody.velocity = playerVelocity;
        bool horizontalSpeed = Mathf.Abs(rigidbody.velocity.x) > Mathf.Epsilon;
        animator.SetBool("run", horizontalSpeed);
    }

    void Flip()
    {
        bool horizontalSpeed = Mathf.Abs(rigidbody.velocity.x) > Mathf.Epsilon;
        if (horizontalSpeed)
        {
            transform.localScale = new Vector2 (Mathf.Sign(rigidbody.velocity.x),1f);
        }
    
    }

    void Die()
    {
       if (bodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemy","Trouble")))
       {
           alive = false;
           animator.SetTrigger("die");
           rigidbody.velocity = deathEffect;
           FindObjectOfType<GameSession>().PlayerDeath();
    
       }
    }

}
