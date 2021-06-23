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

    public GameObject UI;
    public GameObject Ambience;
    public GameObject CompanionSounds;

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

        UI.SetActive(false);
        Ambience.SetActive(false);
        CompanionSounds.SetActive(false);

        videoPlayer.SetActive(true);
        //Destroy(videoPlayer, timeToStop);

    }
    void Update()
    {
        if (video == true)
        {
            StartCoroutine(timer());
        }
    }

    public IEnumerator timer()
    {

        
        yield return new WaitForSeconds(100);
        SceneManager.LoadScene(0);
    }
}