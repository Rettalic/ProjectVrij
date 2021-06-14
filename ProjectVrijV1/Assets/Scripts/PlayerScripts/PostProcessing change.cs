using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class PostProcessingchange : MonoBehaviour
{
    public PostProcessVolume volume;

    private Vignette vignette;
    private AutoExposure autoEx;

    public Slider sliderExpos1;
    public Slider sliderExpos2;

    // Start is called before the first frame update
    void Start()
    {
        volume.profile.TryGetSettings(out vignette);
        volume.profile.TryGetSettings(out autoEx);
        vignette.smoothness.value = 0.75f;
        vignette.intensity.value = 0.138f;


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            vignette.intensity.value = 0.250f;
        }
    }
}
