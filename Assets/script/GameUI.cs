using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public int points = 0;
    public int highScore = 0;

    public Text scoreText;
    public Text highScoreText;
    public Text inputText;
    // Start is called before the first frame update
    void Start()
    {
        highScoreText.text = ("High score: " + PlayerPrefs.GetInt("highScore"));
        highScore = PlayerPrefs.GetInt("highScore",0);

        if (PlayerPrefs.HasKey("points"))
        {
            Scene ActiveScene = SceneManager.GetActiveScene();
            if(ActiveScene.buildIndex == 0)
            {
                PlayerPrefs.DeleteKey("points");
                points = 0;
            }
            else
            { points = PlayerPrefs.GetInt("points"); }    
        }
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = ("Score: " + points);
    }
}
