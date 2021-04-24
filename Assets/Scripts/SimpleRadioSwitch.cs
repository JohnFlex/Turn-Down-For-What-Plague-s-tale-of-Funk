using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SimpleRadioSwitch : MonoBehaviour, IDeselectHandler, ISelectHandler
{
    public Image upButton;

    public Image downButton;

    bool isUp;

    public AudioSource audioSource;

    public AudioClip clicClip;

    public float upPitch = 1;
    public float downPitch = 1;

    public Material uiOutlineMaterial;


    void Awake()
    {
        downButton.enabled = false;
        isUp = true;

    }

    public void OnChangeButton()
    {
        isUp = !isUp;

        downButton.enabled = !isUp;
        upButton.enabled = isUp;

        
        //audioSource.PlayOneShot(clicClip);

        if (isUp)
        {
            audioSource.pitch = upPitch;
            upButton.material = new Material(uiOutlineMaterial);
            downButton.material = null;
        }
        else
        {
            upButton.material = null;
            downButton.material = new Material(uiOutlineMaterial);
            audioSource.pitch = downPitch;
        }

        audioSource.PlayOneShot(clicClip);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        downButton.material = null;
        upButton.material = null;
        Resources.UnloadUnusedAssets();
    }


    public void OnSelect(BaseEventData eventData)
    {
        
        if (isUp)
        {
            upButton.material = new Material(uiOutlineMaterial);
        }
        else
        {
            downButton.material = new Material(uiOutlineMaterial);
        }
    }
}
