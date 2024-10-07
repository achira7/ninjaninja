using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class toMainMenu : MonoBehaviour
{

    private BoxCollider2D toMainMenuBoxCollider;
    // Start is called before the first frame update
    void Start()
    {
        toMainMenuBoxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Invoke("startLevel", 1f);
            SceneManager.LoadScene(0);
        }
    }
}
