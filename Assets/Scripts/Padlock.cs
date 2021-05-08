using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


[RequireComponent(typeof(Image))]
[RequireComponent(typeof(SetToolTip))]
public class Padlock : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    static bool ALREADY_BROKE_KEY_ONCE = false;
    public GameObject newKey, brokenKeyToolTip, goodKeyToolTip;

    public ToolTipSO selected, enteringKey, noKey;


    public GameObject eventSystem, visualPadlock;

    public Color selectedColor;
    Color defaultColor;

    public Material uiOutlineMaterial;

    bool buttonIsPushed = false;

    public enum Status { Up, Push, Down , None};

    public Status[] statusSequence;
    public int statusSequenceIndex = 0;

    public Status actualStatus;

    Controls uiInputs;

    Image imageComponent;

    Vector2 actualJoystickPosition;

    SetToolTip setToolTip;

    [SerializeField]
    Button volumeButton;

    public PlayClipAndShowDialog playElement;
    public AudioClip brokeKey;



    private void Awake()
    {
        setToolTip = GetComponent<SetToolTip>();

        actualStatus = Status.Push;

        uiInputs = new Controls();

        uiInputs.UIRotation.JoystickRotation.performed += ctx =>
        {
            actualJoystickPosition = ctx.ReadValue<Vector2>();
        };

        uiInputs.UIRotation.JoystickRotation.canceled += ctx => actualJoystickPosition = Vector2.zero;

        uiInputs.UIRotation.BackButton.performed += _ => ExitKeyEntering();

        uiInputs.UIRotation.Push.performed += _ => buttonIsPushed = true;
        uiInputs.UIRotation.Push.canceled += _ => buttonIsPushed = false;

        imageComponent = GetComponent<Image>();

        setToolTip = GetComponent<SetToolTip>();
    }


    public void StartKeyEntering()
    {
        if (!PickupCassette.HAS_KEY)
        {
            return;
        }

        uiInputs.UIRotation.Enable();
        eventSystem.GetComponent<EventSystem>().enabled = false;
        eventSystem.GetComponent<UnityEngine.InputSystem.UI.InputSystemUIInputModule>().enabled = false;

        defaultColor = imageComponent.material.GetColor("_OutlineColor");

        imageComponent.material.SetColor("_OutlineColor", selectedColor);

        setToolTip.SetToolTipSO(enteringKey);
        setToolTip.SetToolTipElements();

        MiniGameManager.MiniGameManagerInstance.enabled = false;

        visualPadlock.SetActive(true);
    }


    private void FixedUpdate()
    {
        actualStatus = CheckEnterStatus();

        if (actualStatus == statusSequence[statusSequenceIndex])
        {
            statusSequenceIndex++;
        }


        if (statusSequenceIndex == statusSequence.Length-1)
        {

            if (!ALREADY_BROKE_KEY_ONCE)
            {
                ALREADY_BROKE_KEY_ONCE = true;
                PickupCassette.HAS_KEY = false;
                newKey.SetActive(true);
                brokenKeyToolTip.SetActive(true);
                goodKeyToolTip.SetActive(false);
                statusSequenceIndex = 0;
                ExitKeyEntering();
                playElement.clip = brokeKey;
                playElement.PlayFromExternal();
                
            }
            else
            {
                volumeButton.interactable = true;
            
                ExitKeyEntering();
                Destroy(this.gameObject, 0.2f);
            }
            
        }
        
    }

    public void ExitKeyEntering()
    {
        uiInputs.UIRotation.Disable();

        eventSystem.GetComponent<EventSystem>().enabled = true;
        eventSystem.GetComponent<UnityEngine.InputSystem.UI.InputSystemUIInputModule>().enabled = true;

        imageComponent.material.SetColor("_OutlineColor", defaultColor);

        eventSystem.GetComponent<EventSystem>().SetSelectedGameObject(this.gameObject);

        setToolTip.SetToolTipSO(selected);
        setToolTip.SetToolTipElements();

        visualPadlock.SetActive(false);

        MiniGameManager.MiniGameManagerInstance.enabled = true;

        if (volumeButton.interactable)
        {
            eventSystem.GetComponent<EventSystem>().SetSelectedGameObject(volumeButton.gameObject);
        }
    }


    Status CheckEnterStatus()
    {
        Status returnStatus = Status.None;

        if (actualJoystickPosition.y > 0)
        {
            returnStatus = Status.Up;
        }
        else if (actualJoystickPosition.y < 0)
        {
            returnStatus = Status.Down;
        }
        else if (buttonIsPushed)
        {
            returnStatus = Status.Push;
        }

        return returnStatus;
    }

    public void OnSelect(BaseEventData eventData)
    {
        imageComponent.material = new Material(uiOutlineMaterial);
        
        setToolTip.SetToolTipSO(selected);
        if (!PickupCassette.HAS_KEY)
        {
            setToolTip.SetToolTipSO(noKey);

        }

        
        setToolTip.SetToolTipElements();

    }

    public void OnDeselect(BaseEventData eventData)
    {
        imageComponent.material = null;
        Resources.UnloadUnusedAssets();
    }
}
