using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthbar : MonoBehaviour
{
    private float nextActionTime = 0.0f;
    public float period = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Image image = GetComponent<Image>();
        
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;
            image.fillAmount -= .01f;
        }
    }
}
