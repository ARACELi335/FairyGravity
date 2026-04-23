using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb;
    //private bool isGrounded = false;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 1f;
    }

    void Update()
    {
        // Para móvil
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                rb.gravityScale *= -1;
                rb.velocity =  Vector2.zero;
                animator.SetTrigger("Spin");
                transform.localScale = new Vector3(1, rb.gravityScale, 1);
                
            }
        }

        //// Para pc
        //if (Input.GetMouseButtonDown(0))
        //{
        //    rb.gravityScale *= -1;
        //    Debug.Log("PC");
        //}

    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
    //    {
    //        isGrounded = true;
    //    }
        
    //}

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
    //    {
    //        isGrounded = false;
    //    }

    //}

}
