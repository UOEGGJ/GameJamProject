using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    public static bool keyEnabled = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collided with " + collision);
        if (collision.gameObject.CompareTag("Cherry"))
        {
            Destroy(collision.gameObject);
        
        }

        if (collision.gameObject.CompareTag("Alt-Cherry"))
        {
            Die();

        }
        if (collision.gameObject.CompareTag("key"))
        {
            Destroy(collision.gameObject);
            keyEnabled = true;

        }
    }

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
    }
}
