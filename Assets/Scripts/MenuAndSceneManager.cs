using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuAndSceneManager : MonoBehaviour
{
    public UnityEngine.UI.Button button;
    private void Start()
    {
        if (PlayerPrefs.HasKey("Level"))
        {
            LevelManager.LEVEL = PlayerPrefs.GetInt("Level");
        }
        else
        {
            LevelManager.LEVEL = 1;
        }

        if (LevelManager.LEVEL == 1)
        {
            button.interactable = false;
        }
        
    }

    public void NewGame()
    {
        PlayerPrefs.SetInt("Level", 1);
        PlayerPrefs.SetString("CassetteLevel", "0000000");
        PlayerPrefs.Save();
        FadeOut.FADE_OUT_ELEMENT.FadeToBlack(2f);
        SceneManager.LoadScene(LevelManager.LEVEL);
    }

    public void ContinueGame()
    {
        FadeOut.FADE_OUT_ELEMENT.FadeToBlack(2f);
        SceneManager.LoadScene(LevelManager.LEVEL);
    }

    public void Options()
    {

    }

    public void Exit()
    {
        Application.Quit();
    }
}
