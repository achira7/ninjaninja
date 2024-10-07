using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerLife : MonoBehaviour
{
    private Animator deathAnimation;
    private Rigidbody2D rigidbody;
    [SerializeField] private cameraController camera;

    [SerializeField] private AudioSource audioDeath;

    private void Start()
    {
        deathAnimation = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("trap"))
        {
            audioDeath.Play();
            die();
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("trap"))
        {
            audioDeath.Play();
            die();

        }
    }



    private void die()
    {
        //rigidbody.bodyType = RigidbodyType2D.Static;
        
        deathAnimation.SetTrigger("death");
        
    }


    private void restartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
