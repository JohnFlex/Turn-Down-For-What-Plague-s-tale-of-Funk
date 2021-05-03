using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(HideUI))]
public class PickupCassette : MonoBehaviour
{

    bool isInside;
    public GameObject foundCassetteToolTip;
    [SerializeField]
    AudioClip clipWhenPicked;


    private void Awake()
    {
        PlayerMovement.onTryInteract += TakeCassette;
        foundCassetteToolTip.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"));
        {
            isInside = true;
            if (!RadioCassette.PICKED_UP_CASSETTE_IN_THIS_LEVEL)
            {
                GetComponent<HideUI>().SetUiText("Pick a cassette");
            }
            else
            {
                GetComponent<HideUI>().SetUiText("The trash is empty...");
            }

        }   
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) ;
        {
            isInside = false;
        }
    }

    void TakeCassette()
    {
        
        if (isInside)
        {
            RadioCassette.PICKED_UP_CASSETTE_IN_THIS_LEVEL = true;
            foundCassetteToolTip.SetActive(true);
            PlayerMovement.onTryInteract -= TakeCassette;
            GetComponent<AudioSource>().PlayOneShot(clipWhenPicked);
            StartCoroutine(FlashOnPickup());

        }
    }

    private void OnDestroy()
    {
        PlayerMovement.onTryInteract -= TakeCassette;
    }

    IEnumerator FlashOnPickup()
    {
        for (int i = 0; i < 6; i++)
        {
            foundCassetteToolTip.SetActive(!foundCassetteToolTip.activeSelf);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
