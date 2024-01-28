using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    public Dialogue dialogue;

    [SerializeField] private AudioSource deathSoundEffect;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            deathSoundEffect.Play();
            dialogue.AddDialogAndShow(" Ha ha ha!");
            Die();
        }

        if (collision.gameObject.CompareTag("Alt-Trap"))
        {
            dialogue.AddDialogAndShow(" What did you think??");
            collision.enabled = false;
        }

        if (collision.gameObject.CompareTag("Hidden-Trap"))
        {

            collision.gameObject.GetComponentInChildren<SpriteRenderer>().enabled = true;

        }
    }

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
    }

    private void RestartLevel()
    {
        Debug.Log((SceneManager.GetActiveScene().name).ToString());
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
