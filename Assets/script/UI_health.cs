using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_health : MonoBehaviour
{
    public Sprite[] hearth_sprite;
    public player player;
    public Image image;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.health > 5)
            player.health = 5;
        if (player.health < 0)
            player.health = 0;
        image.sprite = hearth_sprite[player.health];
    }
}
