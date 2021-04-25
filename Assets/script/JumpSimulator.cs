using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpSimulator : MonoBehaviour
{
    public float fallgravity = 2.5f;
    public float jumpgravity = 1.5f;
    Rigidbody2D rigid;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(rigid.velocity.y<0)
        {
            rigid.velocity += Vector2.up * Physics2D.gravity.y * (fallgravity - 1) * Time.deltaTime;
        }
        if(rigid.velocity.y>0 && !Input.GetKey(KeyCode.Space) )
        {
            rigid.velocity += Vector2.up * Physics2D.gravity.y * (jumpgravity - 1) * Time.deltaTime;
        }
    }
}
