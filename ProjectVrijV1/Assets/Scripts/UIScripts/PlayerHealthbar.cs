﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthbar : MonoBehaviour
{
    private float nextActionTime = 0.0f;
    public float period = 0.1f;
    public Transform other;
    public float dist;

    public Image playerOxygenBar;
    public Image playerHealthBar;

    public FollowPlayer2 companionScript;

    public GameObject playerCharacterPortraitDeath;

    // Start is called before the first frame update
    void Start()
    {
        playerCharacterPortraitDeath.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (other)
        {
            dist = Vector3.Distance(other.position, transform.position);
            print("Distance to other: " + dist);
        }

            Image image = GetComponent<Image>();
        if (dist > 5)
        {
            playerOxygenBar.fillAmount -= .002f;
        }

        if (dist < 5)
        {
            playerOxygenBar.fillAmount += .002f;
        }

        if (playerOxygenBar.fillAmount > 1)
        {
            playerOxygenBar.fillAmount = 1;
        }

        if (playerOxygenBar.fillAmount < 0.001)
        {
            playerHealthBar.fillAmount -= .001f;
        }
    }
}
