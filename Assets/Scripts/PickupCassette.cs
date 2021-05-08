using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(HideUI))]
[RequireComponent(typeof(PlayClipAndShowDialog))]
public class PickupCassette : MonoBehaviour
{
    public static bool HAS_KEY = false;
    public static bool HAS_SCREWDRIVER = false;
    public enum Pickable { Cassette, ScrewDriver, Key};
    public Pickable pickable;

    bool isPlayerInside, isObjectInside = true;
    public GameObject foundPickableToolTip;
    [SerializeField]
    AudioClip clipWhenPicked;
    



    private void Awake()
    {
        PlayerMovement.onTryInteract += TakePickable;
        foundPickableToolTip.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"));
        {
            isPlayerInside = true;
            string stringToDisplay = "Pick a " + pickable.ToString();

            if (!isObjectInside)
            {
                stringToDisplay = "It's empty...";
            }
            
            GetComponent<HideUI>().SetUiText(stringToDisplay);
            

        }   
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInside = false;
        }
    }

    void TakePickable()
    {
        
        if (isPlayerInside && isObjectInside)
        {
            switch (pickable)
            {
                case Pickable.Cassette:
                    RadioCassette.PICKED_UP_CASSETTE_IN_THIS_LEVEL = true;
                    break;
                case Pickable.ScrewDriver:
                    HAS_SCREWDRIVER = true;
                    break;
                case Pickable.Key:
                    HAS_KEY = true;
                    break;
                default:
                    break;
            }

            isObjectInside = false;
            foundPickableToolTip.SetActive(true);
            PlayerMovement.onTryInteract -= TakePickable;
            GetComponent<AudioSource>().PlayOneShot(clipWhenPicked);
            GetComponent<PlayClipAndShowDialog>().PlayFromExternal();
            StartCoroutine(FlashOnPickup());

        }
    }

    private void OnDestroy()
    {
        PlayerMovement.onTryInteract -= TakePickable;
    }

    IEnumerator FlashOnPickup()
    {
        for (int i = 0; i < 6; i++)
        {
            foundPickableToolTip.SetActive(!foundPickableToolTip.activeSelf);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
