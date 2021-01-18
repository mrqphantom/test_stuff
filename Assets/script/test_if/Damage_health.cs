using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage_health : MonoBehaviour
{
    public int my_health;
    // Start is called before the first frame update
    void Start()
    {
        Takedamage(10);
    }

    // Update is called once per frame
    void Update()
    {   
        Takedamage(10);
        if(my_health <= 0)
        {
            my_health = 0;
            Destroy(gameObject, 1f);
            Debug.Log("thua roi");
        }
        else if(my_health >= 100)
        {
            Debug.Log("nhap sai");
            
        }
        
    }
    
  void Takedamage(int damage)
    {
        
       my_health -= damage;
}
}
