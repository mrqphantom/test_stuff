using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage_health : MonoBehaviour
{
    public float my_health = 90f;
    // Start is called before the first frame update
    void Start()
    {
        Takedamage(19.6f);
    }

    // Update is called once per frame
    void Update()
    {
        if(my_health <= 0)
        {
            my_health = 0;
            Destroy(gameObject, 2f);
            Debug.Log("thua roi");
        }
        else if(my_health >= 100)
        {
            Debug.Log("nhap sai");
            
        }
    }
  void Takedamage(float damage)
    {
        
        my_health -= Mathf.RoundToInt(damage);
    }
}
