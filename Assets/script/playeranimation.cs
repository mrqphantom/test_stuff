using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playeranimation : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public HealthBar healthBar;
    Transform playerMover;
    Animator Anim;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        playerMover = gameObject.GetComponent<Transform>();
        Anim = gameObject.GetComponent<Animator>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            takedamage(2);
        }
        void takedamage(int damage)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
        }
        if (Input.GetKey(KeyCode.R))
        {
            Anim.SetInteger("status", 2);
            Debug.Log("nhay len");
        }
        
        else if(Input.GetKey(KeyCode.A))
        {
            playerMover.Translate(speed * Vector3.left * Time.deltaTime);
            Anim.SetInteger("status", 1);
            Debug.Log("chay anim walk");
            
        }
        else if(Input.GetKey(KeyCode.D))
        {
            playerMover.Translate(speed * Vector3.right * Time.deltaTime);
            Anim.SetInteger("status", 1);
            Debug.Log("chay anim walk");
        }
        else if(Input.GetKey(KeyCode.S))
        {
            playerMover.Translate(speed * Vector3.down * Time.deltaTime);
            Anim.SetInteger("status", 1);
            Debug.Log("chay anim walk");
        }
        else if(Input.GetKey(KeyCode.W))
        {
            playerMover.Translate(speed * Time.deltaTime * Vector3.up);
            Anim.SetInteger("status", 1);
            Debug.Log("chay anim walk");
        }
        else
        {
            Anim.SetInteger("status", 0);
            Debug.Log("dung im");
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("DeadZone"))
        {
            Destroy(gameObject);
        }
    }
}
