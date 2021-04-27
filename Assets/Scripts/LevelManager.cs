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
        
    }

    void WinLevel()
    {
        LEVEL++;

        PlayerPrefs.SetInt("Level", LEVEL);
        PlayerPrefs.Save();

    }
}
