using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    private bool isDead = false;
    private bool isGlowing = false;

    public GameManager gameManager;
    private Animator animController;

    private float GlowTimer = 0f;
    void Start()
    {
        animController = GetComponent<Animator>();
    }
    void Update()
    {
        if (isDead)
        {
            gameManager.GameOver();
        }
        
        if (isGlowing)
        {
            GlowTimer += Time.deltaTime;
            if (GlowTimer >= 10f)
            {
                GlowTimer = 0f;
                isGlowing = false;
                animController.SetBool("IsGlowing", false);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("DeadZone"))
        {
            Handheld.Vibrate();
            if (isGlowing)
            {
                Collider2D col = collision.gameObject.GetComponent<Collider2D>();
               if(col!= null)
                {
                    col.isTrigger = true;
                }
                isGlowing=false;
                animController.SetBool("IsGlowing", false);
                
                GlowTimer = 0f;
            }
            else
            {
                FindObjectOfType<MusicManager>().PlayDeadMusic();
                StartCoroutine(MorirConAnimacion());
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("DeadZone"))
        {
            isDead = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Glow"))
        {
            isGlowing = true;
            gameManager.score += 5;
            animController.SetBool("IsGlowing", true);
            Destroy(collision.gameObject);
        }
        
        if (collision.gameObject.layer == LayerMask.NameToLayer("Flower"))
        {
            gameManager.score += 1;
            Destroy(collision.gameObject);
        }
    }
    IEnumerator MorirConAnimacion()
    {
        animController.SetTrigger("Die");

        yield return new WaitForSeconds(0.2f); // duración de la animación
        isDead = true;
    }
}
