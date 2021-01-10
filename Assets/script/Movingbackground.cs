using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movingbackground : MonoBehaviour
{
    public float timedelay;
    Rigidbody2D rigid;
    // Start is called before the first frame update
    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.CompareTag("Player"))
        {
            StartCoroutine(fall());
        }
    }
    IEnumerator fall()
    {
        yield return new WaitForSeconds(timedelay);
        rigid.bodyType = RigidbodyType2D.Dynamic;
        yield return 0;

    }
}
