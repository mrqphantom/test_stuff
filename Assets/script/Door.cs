using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public int levelLoad = 1;
    public GameUI gameUI;

    // Start is called before the first frame update
    void Start()
    {
        gameUI = GameObject.FindGameObjectWithTag("gameUI").GetComponent<GameUI>();
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            savescore();
            gameUI.inputText.text = ("press E to enter");
        }
    }
    public void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        { if (Input.GetKey(KeyCode.R))
            {
                savescore();
                SceneManager.LoadScene(levelLoad);
            }
        }    
    }
    public void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
            gameUI.inputText.text = ("");
    }

        void savescore()
    {
        PlayerPrefs.SetInt("coins", gameUI.points);
    }
}
