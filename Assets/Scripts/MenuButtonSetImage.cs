using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuButtonSetImage : MonoBehaviour, ISelectHandler, IDeselectHandler
{

    float speed = 0.01f;
    public UnityEngine.UI.Image toChangeImage;
    public Sprite newSprite;
    public Coroutine dissolveCoroutine;
    
    public void OnSelect(BaseEventData eventData)
    {
        
        dissolveCoroutine = StartCoroutine(DissolveImage());
    }

    IEnumerator DissolveImage()
    {
        
        do
        {
            toChangeImage.material.SetFloat("_Fade", toChangeImage.material.GetFloat("_Fade") - speed);
            yield return new WaitForEndOfFrame();
            Debug.Log(toChangeImage.material.GetFloat("_Fade"));

        } while ((toChangeImage.material.GetFloat("_Fade") >= 0f));


        toChangeImage.sprite = newSprite;

        do
        {
            toChangeImage.material.SetFloat("_Fade", toChangeImage.material.GetFloat("_Fade") + speed);
            yield return new WaitForEndOfFrame();

            
        } while ((toChangeImage.material.GetFloat("_Fade") <= 1f));

    }

    public void OnDeselect(BaseEventData eventData)
    {
        StopCoroutine(dissolveCoroutine);
    }
}
