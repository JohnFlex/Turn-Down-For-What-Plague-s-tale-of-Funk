using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    public Image fadeElement;

    public static FadeOut FADE_OUT_ELEMENT;

    private void Awake()
    {
        if (!FADE_OUT_ELEMENT)
        {
            FADE_OUT_ELEMENT = this;
        }
    }

    public void FadeToBlack(float fadeTime)
    {
        
        fadeElement.color = Color.black;
        fadeElement.canvasRenderer.SetAlpha(0.0f);
        fadeElement.CrossFadeAlpha(1.0f, fadeTime, true);
    }

    public void FadeFromBlack(float fadeTime)
    {
        fadeElement.color = Color.black;
        fadeElement.canvasRenderer.SetAlpha(1.0f);
        fadeElement.CrossFadeAlpha(0.0f, fadeTime, true);
    }

    private void OnEnable()
    {
        FadeFromBlack(1f);
    }

    
}
