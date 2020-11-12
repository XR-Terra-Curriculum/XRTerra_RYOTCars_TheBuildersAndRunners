using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class HoverGlow : MonoBehaviour
{
    public float period = 2f;
    [Range(0, 1)] public float scale;

    public Light oscLight;

    public AudioSource happy;
    public AudioSource sad;


    // Update is called once per frame
    void Update()
    {
        Oscillator();
        GlowEffect();
    }

    public void GlowEffect()
    {
        oscLight.intensity = scale * 3;
        // oscLight.color = new Vector4(0.0f, 0.0f, scale);
    }

    private void Oscillator()
    {
        if (period <= Mathf.Epsilon)
        {
            return;
        }

        float cycle = Time.time / period;
        float tau = Mathf.PI * 2;
        float rawSinWave = Mathf.Sin(cycle * tau);
        scale = rawSinWave / 2f + 0.5f;
        print(scale);
    }



    // SOUNDS

    public void PlayHappy()
    {
        happy.Play();
    }

    public void PlaySad()
    {
        sad.Play();
    }
}
