using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{   public float speed = 50f;
    public int health =100;
    IEnumerator dashcoutine;
    bool isdashing = false;
    bool candash = true;
    public float speedDash;
    float direction = 1;
    float gravity;

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
        dashcoutine = Dash(0.5f, 0f);
        StartCoroutine(dashcoutine);
        gravity = rigid.gravityScale;
       
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Grounded", grounded);
        anim.SetFloat("Speed", Mathf.Abs(rigid.velocity.x));
        
        if ((Input.GetKeyDown(KeyCode.LeftShift) && candash == true))
        {
            if (dashcoutine != null)
            {
                StopCoroutine(dashcoutine);
            }
            dashcoutine = Dash(0.2f, 0.5f);
            StartCoroutine(dashcoutine);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded)
            {
                grounded = false;
                doublejump = true;
                rigid.AddForce((Vector2.up)*height_hight);

            }
            else
            {
                if (doublejump)
                {
                    doublejump = false;
                    grounded = true;
                    rigid.velocity = new Vector2(0, rigid.velocity.y);
                    rigid.AddForce((Vector2.up) * height_hight);
                }
            }
        }
    }
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        rigid.AddForce((Vector2.right) * speed * h);
        if ( h != 0)
        {
            direction = h;
        }
        if(isdashing)
        {
            rigid.AddForce((Vector2.right*4*speed*h));
        }
      
        if ((rigid.velocity.x > maxspeed) && (isdashing == false))
            rigid.velocity = new Vector2(maxspeed, rigid.velocity.y);
        if ((rigid.velocity.x < -maxspeed) && (isdashing == false))
            rigid.velocity = new Vector2(-maxspeed, rigid.velocity.y);
        if(h > 0 && !faceright)
        {
            Flip();
        }
        if(h <0 && faceright)
        {
            Flip();
        }
        if ((grounded) && (isdashing == false))
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
        
        if (health <=0)
        {
            Death();
        }
       
   
    
    }
    IEnumerator Dash(float dashDuartion, float dashCooldown)
    {
        isdashing = true;
        candash = false;
        
        rigid.velocity = Vector2.zero;
        yield return new WaitForSeconds(dashDuartion);
        isdashing = false;
        rigid.gravityScale = gravity;
        rigid.velocity = Vector2.zero;
        yield return new WaitForSeconds(dashCooldown);
        candash = true;

    }
    public void Death()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Hell"))
        {   health -= 1;
            Death();
        }
    }


}
