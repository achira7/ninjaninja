using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startMenu_Play : MonoBehaviour
{

    private BoxCollider2D startBoxCollider;

    void Start()
    {
        startBoxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Invoke("startLevel", 1.5f);
            Debug.Log("Hit");
        }
    }

    private void startLevel()
    {
        SceneManager.LoadScene(1);
    }
}
