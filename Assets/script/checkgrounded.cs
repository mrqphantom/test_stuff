﻿using System.Collections;
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
       
            player.grounded = true;
    }
    public void OnTriggerStay2D(Collider2D col)
    {
        
            player.grounded = true;
    }
    public void OnTriggerExit2D(Collider2D col)
    {
        
            player.grounded = false;

    }

}
