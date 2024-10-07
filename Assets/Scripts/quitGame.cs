using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quitGame : MonoBehaviour
{

    private BoxCollider2D quitBoxCollider;
    private Animator deathAnimation;

    void Start()
    {
        quitBoxCollider = GetComponent<BoxCollider2D>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Invoke("quitGamee", 1.5f);
            Debug.Log("Quit");
        }
    }

    private void quitGamee()
    {
        Application.Quit();
    }
}
