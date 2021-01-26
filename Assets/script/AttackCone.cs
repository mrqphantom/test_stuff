using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCone : MonoBehaviour
{
    public TurretAI turret;
    public bool isLeft;
    // Start is called before the first frame update
    void Awake()
    {
        turret = gameObject.GetComponentInParent<TurretAI>();
       
    }
    private void OnTriggerStay2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        { if (isLeft)
                turret.Attack(false);
          if (!isLeft)
                turret.Attack(true); }
    }

}
