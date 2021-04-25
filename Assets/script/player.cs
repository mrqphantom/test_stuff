using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class player : MonoBehaviour
{   public float speed = 50f;
    public float timedelaydeath =2f;
    public int health =5;
    IEnumerator dashcoutine;
    bool isdashing = false;
    bool candash = true;
    public float speedDash;
    public float maxspeedY;
    float direction = 1;
    float gravity;
    public ParticleSystem effectDash;
   
    public float maxspeed;
    public bool grounded = false;
    public bool faceright = true;
    public bool doublejump = false;
    public float height_hight;
    public Rigidbody2D rigid;
    public Animator anim;
    public HealthBar healthBar;
    public int currentPlayerHealth;
    public GameUI gameUI;

    public Soundmanager audiosrc;
    public cameraShake cameraShake;
    public float timeShake;
    public float magnitudeShake;
    public float slowTime = 0.2f;
    private bool isSlowed = false;
   

    // Start is called before the first frame update
    void Start()
    {
        
        rigid = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        dashcoutine = Dash(0.5f, 0f);
        StartCoroutine(dashcoutine);
        gravity = rigid.gravityScale;
        currentPlayerHealth = health;
        healthBar.setMaxHealth(health);
        audiosrc = GameObject.FindGameObjectWithTag("sound").GetComponent<Soundmanager>();
        gameUI = GameObject.FindGameObjectWithTag("gameUI").GetComponent<GameUI>();

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
            gameObject.GetComponent<Animation>().Play("dash");
            Instantiate(effectDash,transform.position,Quaternion.identity);
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
                    rigid.velocity = new Vector2(rigid.velocity.x,0);
                    rigid.AddForce((Vector2.up) * height_hight * 0.5f);
                }
            }
        }
    }
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        rigid.AddForce((Vector2.right) * speed * h );
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
        if ((rigid.velocity.y > maxspeedY))
            rigid.velocity = new Vector2(rigid.velocity.x, maxspeedY);
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
     

        yield return new WaitForSeconds(dashDuartion);
        isdashing = false;
       
        yield return new WaitForSeconds(dashCooldown);
        candash = true;

    }
   public void Death()
    {
        if (PlayerPrefs.GetInt("highScore") < gameUI.points)
            PlayerPrefs.SetInt("highScore", gameUI.points);
        
        audiosrc.Playsound("endgame");
        StartCoroutine(delaydeath());
       
    }
  
    public void takedamage(int damage)
    {
        health -= damage;
        gameObject.GetComponent<Animation>().Play("hurt");
        healthBar.SetHealth(health);
    }
    IEnumerator delaydeath()
    {
        
        audiosrc.Playsound("endgame");
        yield return new WaitForSeconds(timedelaydeath);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
     


    }
    public void pullback(float pullpower, Vector2 pulldir)
    {
        rigid.velocity = new Vector2(0, 0);
        rigid.AddForce(new Vector2(pulldir.x * -200, pulldir.y * pullpower));
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("coin"))
        {
            audiosrc.Playsound("coins");
            Destroy(col.gameObject);
            gameUI.points += 1;
        }
        if (col.CompareTag("Hell"))
        {
            StartCoroutine(cameraShake.Shake(timeShake, magnitudeShake));
            StartCoroutine(delaydeath());
        }

        if (col.CompareTag("itemLife"))
        {
            
            health = 5;
            Destroy(col.gameObject);
        }
        if(col.CompareTag("itemShoe"))
        {
            
            speed = speed + speed;
            maxspeed = maxspeed + maxspeed;
            Destroy(col.gameObject);
            StartCoroutine(returnNormalSpeed(5f));
        }

    }
    IEnumerator returnNormalSpeed(float time)
    {
        yield return new WaitForSeconds(time);
        maxspeed = maxspeed / 2;
        speed = speed / 2;
        yield return 0;
    }
}
