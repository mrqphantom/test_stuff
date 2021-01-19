using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    public GameObject PauseUI;
    bool PauseIsshow = false;
    // Start is called before the first frame update
    void Start()
    {
        PauseUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseIsshow = !PauseIsshow;
        }
        if (PauseIsshow)
        { PauseUI.SetActive(true);
            Time.timeScale = 0;
        }
        if(PauseIsshow == false)
        {
            PauseUI.SetActive(false);
            Time.timeScale = 1;
        }
    }
    public void Resume()
    {
        PauseIsshow = false;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
    