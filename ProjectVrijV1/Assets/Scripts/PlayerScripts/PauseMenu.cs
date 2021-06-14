using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuobj;
    public bool isPaused;

    public GameObject Optionobj;
    public GameObject MenuObj;


    void Start()
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


}
