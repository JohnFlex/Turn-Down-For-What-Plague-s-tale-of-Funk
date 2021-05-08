using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayClipAndShowDialog : MonoBehaviour
{

    public AudioClip clip;
    public string dialogString;

    static AudioSource globalSource;
    public TMPro.TextMeshProUGUI globalTextShow;

    // Start is called before the first frame update

    void Start()
    {
        if (!globalSource)
        {
            globalSource = new AudioSource();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        globalSource.PlayOneShot(clip);
        StartCoroutine(ShowDialog(dialogString));
    }


    IEnumerator ShowDialog(string dialogLine)
    {
        globalTextShow.gameObject.SetActive(true);
        globalTextShow.text = "";
        foreach (char letter in dialogLine.ToCharArray())
        {
            globalTextShow.text += letter;
            yield return null;
        }

        do
        {
            yield return null;
        } while (globalSource.isPlaying);

        globalTextShow.gameObject.SetActive(false);

    }

}
