using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundmanager : MonoBehaviour
{
    public AudioClip coin, attack, destroy, endgame;
    public AudioSource audiosrc;
    // Start is called before the first frame update
    void Start()
    {
        coin = Resources.Load<AudioClip>("sound/coins");
        attack = Resources.Load<AudioClip>("sound/fire");
        destroy = Resources.Load<AudioClip>("sound/exploration");
        endgame = Resources.Load<AudioClip>("sound/lose");
        audiosrc = GetComponent<AudioSource>();
    }
    public void Playsound(string clip)
    {
        switch(clip)
        {
            case "coins":
                audiosrc.clip = coin;
                audiosrc.PlayOneShot(coin);
                break;
            case "attack":
                audiosrc.clip = attack;
                audiosrc.PlayOneShot(attack,0.05f);
                break;
            case "destroy":
                audiosrc.clip = destroy;
                audiosrc.PlayOneShot(destroy);
                break;
            case "endgame":
                audiosrc.clip = endgame;
                audiosrc.PlayOneShot(endgame);
                break;
        }
    }
}
