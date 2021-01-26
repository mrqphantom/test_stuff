using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAI : MonoBehaviour
{
    public int turretHealth;

    public float distance;
    public float awakeRange;
    public float shootingTime;
    public float bulletSpeed;
    public float bulletTimer;

    public bool awake = false;
    public bool lookRight= true;

    public GameObject bullet;
    public Transform target;
    public Animator anim;
    public Transform shootingPointL, shootingPointR;
    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Awake", awake);
        anim.SetBool("LookRight", lookRight);
        rangeCheck();
        if(target.transform.position.x > transform.position.x)
        {
            lookRight = true;
        }
        if(target.transform.position.x < transform.position.x)
        {
            lookRight = false;
        }
        if (turretHealth<=0)
        {
            Destroy(gameObject);
        }
    }
    void rangeCheck()
    {
        distance = Vector2.Distance(transform.position, target.transform.position);
        if (distance < awakeRange)
        {
            Debug.Log("Gap nhau");
            awake = true;
        }
        if (distance > awakeRange)
        {
            awake = false;
        }
    }
    public void Attack(bool attackRight)
    {
        bulletTimer += Time.deltaTime;
        if (bulletTimer >= shootingTime)
        {
            Vector2 direction = target.transform.position - transform.position;
            direction.Normalize();
            if(attackRight)
            {
                GameObject bulletclone;
                bulletclone = Instantiate(bullet, shootingPointR.transform.position, shootingPointR.transform.rotation) as GameObject;
                bulletclone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
                bulletTimer = 0;
            }
            if (!attackRight)
            {
                GameObject bulletclone;
                bulletclone = Instantiate(bullet, shootingPointL.transform.position, shootingPointL.transform.rotation) as GameObject;
                bulletclone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
                bulletTimer = 0;
            }

        }
    }
   
}
