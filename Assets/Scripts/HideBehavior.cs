using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HideUI))]
public class HideBehavior : MonoBehaviour
{
    public GameObject player;

    public GameObject exitPoint;

   
    bool isPlayerInside = false;

    HideUI hideUI;

    public static bool HIDE_STATUS;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        PlayerMovement.onTryInteract += TriggerHide;
        hideUI = GetComponent<HideUI>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInside = true;
            hideUI.SetUiText();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInside = false;
        }
    }

    void TriggerHide()
    {
        if (!isPlayerInside) return;


        if (!HIDE_STATUS)
        {
            HIDE_STATUS = true;
            
            GetComponent<HideUI>().SetUiText();

            if (exitPoint)
            {
                gameObject.transform.parent.GetComponent<BoxCollider2D>().isTrigger = true;
                player.transform.position = gameObject.transform.parent.transform.position;
            }
        }
        else
        {
            HIDE_STATUS = false;
            
            GetComponent<HideUI>().SetUiText();

            if (exitPoint)
            {
                player.transform.position = exitPoint.transform.position;
                gameObject.transform.parent.GetComponent<BoxCollider2D>().isTrigger = false;
            }
        }

        

    }

    private void OnDestroy()
    {
        PlayerMovement.onTryInteract -= TriggerHide;
    }
}
