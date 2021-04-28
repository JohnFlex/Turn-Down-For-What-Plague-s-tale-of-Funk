using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class HideUI : MonoBehaviour
{
    [SerializeField]
    GameObject panel;

    [SerializeField]
    TextMeshProUGUI textMesh;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;

        panel.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        panel.SetActive(false);
    }

    public void SetUiText()
    {
        textMesh.text = HideBehavior.HIDE_STATUS ? "Exit" : "Hide";
    }

    public void SetUiText(string text)
    {
        textMesh.text = text;
    }
}
