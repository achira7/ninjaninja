using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class woodenBoxSound : MonoBehaviour
{

    private AudioSource boxImpactSound;
    private bool alreadyTouchingBox = false;
    // Start is called before the first frame update
    void Start()
    {
        boxImpactSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if(alreadyTouchingBox == false)
        {
            if (collision.gameObject.name == "Player" || collision.gameObject.tag == "Ground")
            {
                boxImpactSound.Play();
            }
        } 
    }

   private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            alreadyTouchingBox = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            alreadyTouchingBox = false;
        }
    }


}
