using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class PostProcessChange : MonoBehaviour
{
    public PostProcessVolume volume;

    private Vignette vignette;
    private AutoExposure autoEx;

    public float smoothValueB = 0.75f;
    public float intensValueB = 0.138f;

    public float smoothValueE;
    public float intenseValueE;

    public Slider sliderExpos1;
    private float slidervalue1;
    public Slider sliderExpos2;

    // Start is called before the first frame update
    void Start()
    {
        volume.profile.TryGetSettings(out vignette);
        volume.profile.TryGetSettings(out autoEx);

        vignette.smoothness.value = smoothValueB;
        vignette.intensity.value = intensValueB;


    }

    // Update is called once per frame
    void Update()
    {
        sliderExpos1.value = slidervalue1;

        autoEx.minLuminance.value = slidervalue1;
        if (Input.GetKeyDown(KeyCode.P))
        {
            vignette.intensity.value += intenseValueE;
        }
    }
}
