using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthbar : MonoBehaviour
{
    private float nextActionTime = 0.0f;
    public float period = 0.1f;

    public GameObject playerCharacterPortraitDeath;

    // Start is called before the first frame update
    void Start()
    {
        playerCharacterPortraitDeath.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Image image = GetComponent<Image>();
        
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;
            image.fillAmount -= .01f;

            if(image.fillAmount < 0.00001) {
                playerCharacterPortraitDeath.SetActive(true);
            }
        }
    }
}
