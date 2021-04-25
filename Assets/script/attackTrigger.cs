using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackTrigger : MonoBehaviour
{
    public int damage = 20;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.isTrigger != false && col.CompareTag("Enemy"))
        {
            col.SendMessageUpwards("turretTakeDamage", damage);
        }
    }
}