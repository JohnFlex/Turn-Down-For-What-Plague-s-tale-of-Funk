using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static int LEVEL = 1;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("Level"))
        {
            PlayerPrefs.SetInt("Level", 1);
            PlayerPrefs.Save();
        }

        LEVEL = PlayerPrefs.GetInt("Level");

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public static void WinLevel()
    {
        LEVEL++;

        PlayerPrefs.SetInt("Level", LEVEL);
        PlayerPrefs.Save();

        if (LEVEL == 3)
        {
            LEVEL = 0;
        }
        SceneManager.LoadScene(LEVEL);
    }
}
