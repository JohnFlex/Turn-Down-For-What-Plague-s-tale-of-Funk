using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RotationButton))]
public class ScrewManager : MonoBehaviour
{
    RotationButton rotBtnElement;
    [SerializeField]
    GameObject glassPanel, selectedGameobject;

    static int screwsToDrop = 4;

    public List<Button> buttonsToActivateOnPanelDrop;

    Button thisButton;

    public UnityEngine.EventSystems.EventSystem eventSystem;


    public PlayClipAndShowDialog playElement;

    public AudioClip finishedScrewdriver;


    // Start is called before the first frame update
    void Start()
    {
        rotBtnElement = GetComponent<RotationButton>();
        thisButton = GetComponent<Button>();

        
    }

    // Update is called once per frame
    void Update()
    {

        if (rotBtnElement.rotationValue <= 0 && thisButton.interactable)
        {
            GetComponent<Image>().color = new Color(0,0,0,0);

            GetComponent<Button>().interactable = false;
            screwsToDrop--;
            rotBtnElement.ExitRotation();
            if (screwsToDrop == 0)
            {
                
                foreach (Button item in buttonsToActivateOnPanelDrop)
                {
                    item.interactable = true;
                }
                
                

                eventSystem.SetSelectedGameObject(selectedGameobject);
                
                eventSystem.firstSelectedGameObject = buttonsToActivateOnPanelDrop[0].gameObject;

                glassPanel.SetActive(false);
                
            }
        }
    }
}
