using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemCollector : MonoBehaviour
{

    [SerializeField]private int kiwis = 0;
    [SerializeField] private Text kiwisCollected;

    [SerializeField] private AudioSource audioCollect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("kiwi"))
        {
            audioCollect.Play();
            Destroy(collision.gameObject);
            kiwis ++;
            kiwisCollected.text = "Kiwis Collected: " + kiwis;
        }
    }
}
