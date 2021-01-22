using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{
    public bool Attacking = false;
    public float timedelay = 0.3f;
    public Animator anim;
    public Collider2D trigger;
    // Start is called before the first frame update
    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        trigger.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !Attacking)
        {
            Attacking = true;
            trigger.enabled = true;
            timedelay = 0.3f;
        }
        if (Attacking)
        {
            {
                if (timedelay > 0)
                {
                    timedelay -= Time.deltaTime;
                }

                else
                {
                    Attacking = false;
                    trigger.enabled = false;
                }
            }
            anim.SetBool("Attacking", Attacking);

        }
    }
}
