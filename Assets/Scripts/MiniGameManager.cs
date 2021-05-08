using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(HideUI))]
public class MiniGameManager : MonoBehaviour
{
    bool playerIsIn;

    public GameObject firstItem;

    public UnityEngine.EventSystems.EventSystem eventSystem;

    static MiniGameManager _miniGameManager;
    public static MiniGameManager MiniGameManagerInstance
    {
        get
        {
            return _miniGameManager;
        }
    }

    public GameObject canvasMiniGame;

    Controls controls;

    PlayerMovement playerMovement;

    public GameObject[] ennemies;

    private void Start()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();

        
        _miniGameManager = this;
        

        controls = new Controls();

        controls.BackMiniGame.Back.performed += _ => CloseMiniGame();

        PlayerMovement.onTryInteract += OpenMiniGame;
    }


    public void OpenMiniGame()
    {
        if (playerIsIn)
        {
            
            playerMovement.enabled = false;

            if (ennemies.Length != 0)
            {
                foreach (GameObject item in ennemies)
                {
                    item.SetActive(false);
                }
            }

            GetComponent<PlayClipAndShowDialog>().PlayFromExternal();

            Invoke("InvokedSelection", 0.05f);


            
        }
        
    }


    public void CloseMiniGame()
    {
        canvasMiniGame.SetActive(false);
        controls.BackMiniGame.Disable();
        playerMovement.enabled = true;

        if (ennemies.Length != 0)
        {
            foreach (GameObject item in ennemies)
            {
                item.SetActive(true);
            }
        }

    }

    

    public void WinMiniGame()
    {
        PlayerMovement.onTryInteract -= OpenMiniGame;
        CloseMiniGame();
        LevelManager.WinLevel();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GetComponent<HideUI>().SetUiText("Interact");
            playerIsIn = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            playerIsIn = false;
        }
    }

    void InvokedSelection()
    {
        eventSystem.SetSelectedGameObject(firstItem);
        canvasMiniGame.SetActive(true);
        controls.BackMiniGame.Enable();
    }
}
