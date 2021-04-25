using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowing : MonoBehaviour
{   public float smoothx;
    public float smoothy;
    public Vector2 velocity;
    public GameObject player;
    public Vector2 minpos;
    public Vector2 maxpos;
    public bool turnOnLimitCamera;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(this.transform.position.x,player.transform.position.x,ref velocity.x, smoothx);
        float posY = Mathf.SmoothDamp(this.transform.position.y, player.transform.position.y, ref velocity.y, smoothy);
        transform.position = new Vector3(posX, posY, transform.position.z);
        if (turnOnLimitCamera)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minpos.x, maxpos.x), Mathf.Clamp(transform.position.y, minpos.y, maxpos.y),Mathf.Clamp(transform.position.z,transform.position.z, 
                transform.position.z));
        }



    }
 

}
