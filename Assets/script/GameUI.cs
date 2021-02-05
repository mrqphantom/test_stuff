using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{

    public int countdownTime;
    public Text countdownText;
    public GameObject stopBar;

    public int points = 0;
    public int highScore = 0;
   
    
    public Text scoreText;
    public Text highScoreText;
    public Text inputText;
    // Start is called before the first frame update

    void Start()
    {
        stopBar = GameObject.FindGameObjectWithTag("stopBar");
       
        Debug.Log("xuat hien roi ne");
        
        highScoreText.text = ("High score: " + PlayerPrefs.GetInt("highScore").ToString());
        highScore = PlayerPrefs.GetInt("highScore",0);

        if (PlayerPrefs.HasKey("points"))
        {
            Scene ActiveScene = SceneManager.GetActiveScene();
            if(ActiveScene.buildIndex == 0)
            {
                stopBar.SetActive(true);
                PlayerPrefs.DeleteKey("points");
                points = 0;
            }
            else
            { points = PlayerPrefs.GetInt("points");
                stopBar.SetActive(false);
            }
            
        }
       
        StartCoroutine(Coundownt());
    }
    IEnumerator Coundownt()
    {
        while (countdownTime > 0)
        {
            countdownText.text = countdownTime.ToString();
            yield return new WaitForSeconds(1f);
            countdownTime--;
        }
        
        countdownText.text = "GO";
        countdownText.color = Color.red;
        yield return new WaitForSeconds(1f);
        
        countdownText.gameObject.SetActive(false);
        DestroyImmediate(stopBar);
    }
   
    // Update is called once per frame
    void Update()
    {
        scoreText.text = ("Score: " + points);
    }
   
}
