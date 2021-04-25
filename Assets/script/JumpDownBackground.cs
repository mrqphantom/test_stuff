using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpDownBackground : MonoBehaviour
{
 private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.S))
                gameObject.GetComponent<Collider2D>().enabled = false;

        }    
    }
    private void OnCollisionExit2D(Collision2D collision)
    { if (collision.collider.CompareTag("Player"))
        {
            Invoke("restore", 2f);
        }
    }
    void restore()
    {
        gameObject.GetComponent<Collider2D>().enabled = true;
    }
}
