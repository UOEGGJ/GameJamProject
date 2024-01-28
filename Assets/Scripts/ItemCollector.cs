using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    public static bool keyEnabled = false;

    [SerializeField] private AudioSource collectSoundEffect;
    [SerializeField] private AudioSource deathSoundEffect;
    [SerializeField] private GameObject CatImage;

    private void Start()
    {
        CatImage.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        Debug.Log("Collided with " + collision);

        if (collision.gameObject.CompareTag("Cherry"))
        {
            collectSoundEffect.Play();
            Destroy(collision.gameObject);
        
        }

        if (collision.gameObject.CompareTag("Alt-Cherry"))
        {
            deathSoundEffect.Play();
            Die();

        }
        if (collision.gameObject.CompareTag("Key"))
        {
            Debug.Log("yes, its key");
            PlayerMovement.isDoubleJump = true;
            Destroy(collision.gameObject);
            keyEnabled = true;
            CatImage.SetActive(true);


        }
    }

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
    }
}
