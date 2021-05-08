using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayClipAndShowDialog : MonoBehaviour
{
    public bool playOnEnter;
    public AudioClip clip;
    [TextArea(3,10)]
    public string dialogString;

    public AudioSource globalSource;
    public TMPro.TextMeshProUGUI globalTextShow;

    // Start is called before the first frame update

    void Start()
    {
        if (globalSource == null)
        {
            globalSource = new AudioSource();
        }
        Debug.Log(globalSource);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (playOnEnter)
        {
            globalSource.PlayOneShot(clip);
            globalTextShow.text = dialogString;
            StartCoroutine(DelayDesactivation());
            gameObject.SetActive(false);
        }
    }


    IEnumerator DelayDesactivation()
    {
        

        do
        {
            yield return null;
        } while (globalSource.isPlaying);

        globalTextShow.gameObject.SetActive(false);

        
    }

    public void PlayFromExternal()
    {
        globalSource.PlayOneShot(clip);
        globalTextShow.text = dialogString;
        StartCoroutine(DelayDesactivation());
    }

}
