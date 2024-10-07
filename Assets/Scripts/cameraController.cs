using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform player;

    // Update is called once per frame


    private bool continueUpdate = true;


    void Update()
    {
        if (continueUpdate == true)
        {
            transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
        }
       else
        { }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("trap"))
        {
            continueUpdate = false;
        }
    }
}
