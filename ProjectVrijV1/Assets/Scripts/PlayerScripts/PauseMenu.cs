using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuobj;
    public bool isPaused;

    public GameObject Optionobj;
    public GameObject MenuObj;


    void Awake()
    {
        pauseMenuobj.SetActive(false);

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (isPaused)
            {
                ResumeGame();
            }
            else {
                PauseGame();
            }
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(0);
        }

    }

    public void PauseGame()
    {
        pauseMenuobj.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenuobj.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void OptionsMenu()
    {
        MenuObj.SetActive(false);
        Optionobj.SetActive(true);

    }

    public void GoBackMenu()
    {
        MenuObj.SetActive(true);
        Optionobj.SetActive(false);
    }

    public void MainMenuChange()
    {
        Time.timeScale = 1f;
        Debug.Log("te");
        SceneManager.LoadScene(0);
    }

    public void change()
    {

    }


}
