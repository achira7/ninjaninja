using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class levelFinish : MonoBehaviour
{
    private AudioSource audioComplete;
    private Animator flagAnimation;
    private bool audioComplateSoundPlayed = false;

    private void Start()
    {
        audioComplete = GetComponent<AudioSource>();
        flagAnimation = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && audioComplateSoundPlayed == false)
        {
                audioComplete.Play();
                audioComplateSoundPlayed = true;
                flagAnimation.SetTrigger("flagRise");
        }
    }

    private void loadNextLevel()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
