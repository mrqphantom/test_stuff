using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkgrounded : MonoBehaviour
{
    public player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<player>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
     
    }
    public void OnTriggerEnter2D(Collider2D col)
    {
       if(col.CompareTag("ground"))
            player.grounded = true;
    }
    public void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("ground"))
            player.grounded = true;
    }
    public void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("ground"))
            player.grounded = false;

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("ground"))
            this.transform.parent = col.transform;
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("ground"))
                this.transform.parent = null;

    }
}
