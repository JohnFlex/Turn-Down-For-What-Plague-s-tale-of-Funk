using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetToolTip : MonoBehaviour
{

    public Image firstElementImage, secondElementImage, thirdElementImage;
    public TextMeshProUGUI firstElementText, secondElementText, thirdElementText;
    public GameObject additionalText;


    public ToolTipSO toDisplayScriptableObject;
    

    public void SetToolTipElements()
    {
        thirdElementImage.sprite = toDisplayScriptableObject.toolTipImage[toDisplayScriptableObject.toolTipImage.Length - 1];
        thirdElementText.text = toDisplayScriptableObject.toolTipText[toDisplayScriptableObject.toolTipText.Length - 1];

        secondElementImage.sprite = toDisplayScriptableObject.toolTipImage[toDisplayScriptableObject.toolTipImage.Length - 2];
        secondElementText.text = toDisplayScriptableObject.toolTipText[toDisplayScriptableObject.toolTipText.Length - 2];

        if (toDisplayScriptableObject.toolTipImage.Length >= 3)
        {
            additionalText.SetActive(true);
            firstElementImage.sprite = toDisplayScriptableObject.toolTipImage[toDisplayScriptableObject.toolTipImage.Length - 3];
            firstElementText.text = toDisplayScriptableObject.toolTipText[toDisplayScriptableObject.toolTipText.Length - 3];
        }
        else
        {
            additionalText.SetActive(false);
        }
    }

    public void SetToolTipSO(ToolTipSO toolTipSO)
    {
        toDisplayScriptableObject = toolTipSO;
    }
}
