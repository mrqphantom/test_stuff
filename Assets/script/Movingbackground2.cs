using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movingbackground2 : MonoBehaviour
{
    public float speed;
    public float changedir = -1;
   
    Vector3 move;
    // Start is called before the first frame update
    void Start()
    {
        move = this.transform.position;
       
    }

    // Update is called once per frame
    void Update()
    {
        move.x += speed;
        this.transform.position = move;

    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.CompareTag("ground"))
        {
            Debug.Log("va cham");
            speed = speed * changedir;
        }
        
    }
  

}
