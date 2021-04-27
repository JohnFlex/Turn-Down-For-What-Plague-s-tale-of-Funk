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

    GameObject[] ennemies;

    private void Awake()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();

        if (!_miniGameManager)
        {
            _miniGameManager = this;
        }

        controls = new Controls();

        controls.BackMiniGame.Back.performed += _ => CloseMiniGame();

        PlayerMovement.onTryInteract += OpenMiniGame;
    }


    public void OpenMiniGame()
    {
        if (playerIsIn)
        {
            
            playerMovement.enabled = false;
            


            Invoke("InvokedSelection", 0.05f);


            
        }
        
    }


    public void CloseMiniGame()
    {
        canvasMiniGame.SetActive(false);
        controls.BackMiniGame.Disable();
        playerMovement.enabled = true;

    }

    

    public void WinMiniGame()
    {
        Debug.Log("Win !");
        CloseMiniGame();
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
        //eventSystem.SetSelectedGameObject(firstItem);
        canvasMiniGame.SetActive(true);
        controls.BackMiniGame.Enable();
    }
}
