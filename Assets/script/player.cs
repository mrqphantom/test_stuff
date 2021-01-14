using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{   public float speed = 50f;
 
    

    public float maxspeed;
    public bool grounded;
    public bool faceright;
    public bool doublejump;
    public float height_hight;
    public Rigidbody2D rigid;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
       
       
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Grounded", grounded);
        anim.SetFloat("Speed", Mathf.Abs(rigid.velocity.x));
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded)
            {
                grounded = false;
                doublejump = true;
                rigid.AddForce(Vector2.up * height_hight);
            }
            else
            {
                if (doublejump)
                {
                    doublejump = false;
                    rigid.velocity = new Vector2(rigid.velocity.x, 0);
                    rigid.AddForce(Vector2.up * height_hight * 0.5f);
                }
            }
        }
    }
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        rigid.AddForce((Vector2.right) * speed * h);
        if (rigid.velocity.x > maxspeed)
            rigid.velocity = new Vector2(maxspeed, rigid.velocity.y);
        if (rigid.velocity.x < -maxspeed)
            rigid.velocity = new Vector2(-maxspeed, rigid.velocity.y);
        if(h > 0 && !faceright)
        {
            Flip();
        }
        if(h <0 && faceright)
        {
            Flip();
        }
        if (grounded)
        {
            rigid.velocity = new Vector2(rigid.velocity.x * 1/2f, rigid.velocity.y);
        }
        void Flip()
        {
            faceright = !faceright;
            Vector3 Scale;
            Scale = transform.localScale;
            Scale.x *= -1;
            transform.localScale = Scale;
        }
   
    
    }
   

}
