using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameManager : MonoBehaviour
{
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

    private void Awake()
    {
        if (!_miniGameManager)
        {
            _miniGameManager = this;
        }

        controls = new Controls();

        controls.BackMiniGame.Back.performed += _ => CloseMiniGame();
    }


    public void OpenMiniGame()
    {
        canvasMiniGame.SetActive(true);
        controls.BackMiniGame.Enable();
    }


    public void CloseMiniGame()
    {
        canvasMiniGame.SetActive(false);
        controls.BackMiniGame.Disable();
    }

    

    private void OnEnable()
    {
        controls.BackMiniGame.Enable();
    }
    
    private void OnDisable()
    {
        controls.BackMiniGame.Disable();
    }

    public void WinMiniGame()
    {
        Debug.Log("Win !");
    }
}
