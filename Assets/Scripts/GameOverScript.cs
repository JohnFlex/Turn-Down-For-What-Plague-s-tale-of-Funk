using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameOverScript
{

    


    public static void GameOver()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerMovement>().enabled = false;

        FadeOut.FADE_OUT_ELEMENT.FadeToBlack(1f);

        player.transform.position = GameObject.FindGameObjectWithTag("SpawnPoint").transform.position;

        FadeOut.FADE_OUT_ELEMENT.FadeFromBlack(2f);

        player.GetComponent<PlayerMovement>().enabled = true;


    }

    
}
