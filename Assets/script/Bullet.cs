using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 1f;
    public player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(lifeTime<=0)
        {
            lifeTime -= Time.deltaTime;
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    { if (col.isTrigger == false)
            if (col.CompareTag("Player"))
                { col.SendMessageUpwards("takedamage", 2);
                Destroy(gameObject);
                player.pullback(500f, player.transform.position);
            }
        
    }
}
