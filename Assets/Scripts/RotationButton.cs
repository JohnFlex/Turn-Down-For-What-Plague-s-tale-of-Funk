using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


[RequireComponent(typeof(Image))]
[RequireComponent(typeof(SetToolTip))]
public class RotationButton : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    public AudioSource radioSource;
    public bool isVolume;

    public ToolTipSO selected;
    public ToolTipSO rotate, noScrewDriver;

    public float rotationSpeed;
    public float damping;

    public float rotationValue;
    public float rotationValueStep;

    public GameObject eventSystem;

    public Color selectedColor;
    Color defaultColor;

    public Material uiOutlineMaterial;

    float desiredRotation;

    enum Rotation { Left, None, Right};

    Rotation actualRotation;

    Controls uiInputs;

    Image imageComponent;

    Vector2 oldJoystickPosition, actualJoystickPosition;

    SetToolTip setToolTip;

    

    private void Awake()
    {
        setToolTip = GetComponent<SetToolTip>();

        actualRotation = Rotation.None;

        uiInputs = new Controls();

        uiInputs.UIRotation.JoystickRotation.performed += ctx =>
        {
            actualJoystickPosition =  ctx.ReadValue<Vector2>();
        };

        uiInputs.UIRotation.JoystickRotation.canceled += ctx => actualJoystickPosition = Vector2.zero;

        uiInputs.UIRotation.BackButton.performed += _ => ExitRotation();

        desiredRotation = transform.rotation.z;

        imageComponent = GetComponent<Image>();

        oldJoystickPosition = Vector2.zero;

        setToolTip = GetComponent<SetToolTip>();
    }


    public void StartRotation()
    {

        if (TryGetComponent<ScrewManager>(out ScrewManager screwManager)  && !PickupCassette.HAS_SCREWDRIVER)
        {
            return;
        }

        uiInputs.UIRotation.Enable();
        eventSystem.GetComponent<EventSystem>().enabled = false;
        eventSystem.GetComponent<UnityEngine.InputSystem.UI.InputSystemUIInputModule>().enabled = false;

        defaultColor = imageComponent.material.GetColor("_OutlineColor");

        imageComponent.material.SetColor("_OutlineColor", selectedColor);

        setToolTip.SetToolTipSO(rotate);
        setToolTip.SetToolTipElements();

        MiniGameManager.MiniGameManagerInstance.enabled = false;
    }


    private void FixedUpdate()
    {
        actualRotation = CheckSpinRotation();
        
        switch (actualRotation)
        {
            case Rotation.Left:
                desiredRotation -= rotationSpeed;
                
                rotationValue += rotationValueStep;

                if (isVolume && rotationValue > 100)
                {
                    rotationValue = 100;
                }
                break;

            case Rotation.Right:
                desiredRotation += rotationSpeed;
                rotationValue -= rotationValueStep;

                if (isVolume && rotationValue < 0)
                {
                    rotationValue = 0;
                }
                break;
            default:
                break;
        }

        var desiredRotQ = Quaternion.Euler(0, 0, desiredRotation);
        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotQ, Time.deltaTime * damping);

        if (isVolume)
        {
            radioSource.volume = rotationValue / 100;
            if (rotationValue <= 5)
            {
                MiniGameManager.MiniGameManagerInstance.WinMiniGame();
            }
        }
    }




    public void ExitRotation()
    {
        uiInputs.UIRotation.Disable();

        eventSystem.GetComponent<EventSystem>().enabled = true;
        eventSystem.GetComponent<UnityEngine.InputSystem.UI.InputSystemUIInputModule>().enabled = true;

        imageComponent.material.SetColor("_OutlineColor", defaultColor);

        eventSystem.GetComponent<EventSystem>().SetSelectedGameObject(this.gameObject);

        setToolTip.SetToolTipSO(selected);
        setToolTip.SetToolTipElements();

        MiniGameManager.MiniGameManagerInstance.enabled = true;
    }


    Rotation CheckSpinRotation()
    {
        Rotation returnRotation = Rotation.None;

        if (oldJoystickPosition.y > 0)
        {
            if (oldJoystickPosition.x > actualJoystickPosition.x)
            {
                returnRotation = Rotation.Right;
            }
            else if (oldJoystickPosition.x < actualJoystickPosition.x)
            {
                returnRotation = Rotation.Left;
            }
            else if (Mathf.Approximately(oldJoystickPosition.x, actualJoystickPosition.x))
            {
                returnRotation = Rotation.None;
            }  
        }
        else if (oldJoystickPosition.y < 0)
        {
            if (oldJoystickPosition.x < actualJoystickPosition.x)
            {
                returnRotation = Rotation.Right;
            }
            else if (oldJoystickPosition.x > actualJoystickPosition.x)
            {
                returnRotation = Rotation.Left;
            }
            else if (Mathf.Approximately(oldJoystickPosition.x, actualJoystickPosition.x))
            {
                returnRotation = Rotation.None;
            }
        }

        oldJoystickPosition = actualJoystickPosition;

        return returnRotation;
    }

    public void OnSelect(BaseEventData eventData)
    {
        imageComponent.material = new Material(uiOutlineMaterial);

        setToolTip.SetToolTipSO(selected);
        

        if (TryGetComponent<ScrewManager>(out ScrewManager screwManager) && !PickupCassette.HAS_SCREWDRIVER)
        {
            setToolTip.SetToolTipSO(noScrewDriver);
        }
        
        setToolTip.SetToolTipElements();

    }

    public void OnDeselect(BaseEventData eventData)
    {
        imageComponent.material = null;
        Resources.UnloadUnusedAssets();
    }
}
