using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(Button))]
[RequireComponent(typeof(SetToolTip))]
public class RadioCassette : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    static bool HAS_CASSETTE_IN_THIS_LEVEL;
    public static bool PICKED_UP_CASSETTE_IN_THIS_LEVEL;

    Image localImage;
    public Material uiOutlineMaterial;
    Button localButton;
    SetToolTip localSetToolTip;

    public ToolTipSO noCassetteToolTip, changeCassetteToolTip, alreadyChangedToolTip;
    public Color noCassetteColor, canChangeColor, alreadyChangedColor;


    // Start is called before the first frame update
    void Start()
    {
        localImage = GetComponent<Image>();
        localButton = GetComponent<Button>();
        localSetToolTip = GetComponent<SetToolTip>();

#if UNITY_EDITOR
        PlayerPrefs.DeleteAll();
#endif


        if (!PlayerPrefs.HasKey("CassetteLevel"))
        {
            PlayerPrefs.SetString("CassetteLevel", "0000000");
            PlayerPrefs.Save();
        }

        if (PlayerPrefs.GetString("CassetteLevel")[LevelManager.LEVEL] == '1')
        {
            HAS_CASSETTE_IN_THIS_LEVEL = true;
        }

    }

    public void ChangeCassetteInThisLevel()
    {
        if (!HAS_CASSETTE_IN_THIS_LEVEL && PICKED_UP_CASSETTE_IN_THIS_LEVEL)
        {
            char[] cassetteByLevel = PlayerPrefs.GetString("CassetteLevel").ToCharArray();

            cassetteByLevel[LevelManager.LEVEL] = '1';

            PlayerPrefs.SetString("CassetteLevel", cassetteByLevel.ToString());

            HAS_CASSETTE_IN_THIS_LEVEL = true;

            localSetToolTip.SetToolTipSO(alreadyChangedToolTip);
            localSetToolTip.SetToolTipElements();
            localImage.material.SetColor("_OutlineColor", alreadyChangedColor);
            
        }
        
    }

    public void OnSelect(BaseEventData eventData)
    {

        localImage.material = new Material(uiOutlineMaterial);

        if (HAS_CASSETTE_IN_THIS_LEVEL)
        {
            localSetToolTip.SetToolTipSO(alreadyChangedToolTip);
            localSetToolTip.SetToolTipElements();
            localImage.material.SetColor("_OutlineColor", alreadyChangedColor);
        }
        else if (PICKED_UP_CASSETTE_IN_THIS_LEVEL)
        {
            localSetToolTip.SetToolTipSO(changeCassetteToolTip);
            localSetToolTip.SetToolTipElements();
            localImage.material.SetColor("_OutlineColor", canChangeColor);
        }
        else
        {
            localSetToolTip.SetToolTipSO(noCassetteToolTip);
            localSetToolTip.SetToolTipElements();
            localImage.material.SetColor("_OutlineColor", noCassetteColor);
        }

    }

    public void OnDeselect(BaseEventData eventData)
    {
        localImage.material = null;
        Resources.UnloadUnusedAssets();
    }
}
