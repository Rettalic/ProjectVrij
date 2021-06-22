using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayVideo : MonoBehaviour
{
    public GameObject videoPlayer;
    public int timeToStop;
    public float timeLeft = 20f;
    public bool video;

    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.SetActive(false);
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider player)
    {
        video = true;
        Debug.Log(timeLeft);

        videoPlayer.SetActive(true);
        //Destroy(videoPlayer, timeToStop);

    }
    void Update()
    {
        if (video == true)
        {
            timeLeft -= Time.deltaTime;

            if (timeLeft == 0)
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}