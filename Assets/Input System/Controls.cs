// GENERATED AUTOMATICALLY FROM 'Assets/Input System/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""a1b73383-cd81-4046-9c9c-f4a9a29db433"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""d7e14b04-631b-46d7-a332-a02bec36d386"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interaction"",
                    ""type"": ""Button"",
                    ""id"": ""5eca70fc-20eb-4332-aa95-dcaa38c797ab"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""69fe3d85-9f1e-4f7e-9302-2d0d0dfafa7c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""006cc938-cdcb-45eb-9246-502401f1e698"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""d80162c9-7efb-4409-9f7f-a8a3483c71fb"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""ce157d4f-a6a9-4abe-9c4d-a8457aa669b1"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""4491e3ec-3426-49f8-b740-9bcd22e177e0"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""4971b1e2-be05-4999-baac-4dfcb961919f"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""d830ca74-afe3-4e36-a79b-1493b5a0860f"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Interaction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fe7708c3-3be3-4a65-a900-b5477004a72b"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UIRotation"",
            ""id"": ""ca677cd7-f3bd-4f68-b403-2e0ba2cd8c96"",
            ""actions"": [
                {
                    ""name"": ""Joystick Rotation"",
                    ""type"": ""PassThrough"",
                    ""id"": ""7642981e-7a72-4877-ba7b-894af6254934"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""BackButton"",
                    ""type"": ""Button"",
                    ""id"": ""1d3b1ed4-b6dd-4405-9d6b-e26bc75efe39"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Push"",
                    ""type"": ""Button"",
                    ""id"": ""7dea5589-ee2b-45ba-a0f3-da2c6fa94df5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""cf99665e-bf80-4ac4-b808-28e842f5726d"",
                    ""path"": ""2DVector(mode=1)"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone(min=0.2,max=0.8)"",
                    ""groups"": """",
                    ""action"": ""Joystick Rotation"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""3efabf79-1a3d-4f80-a15b-f7c0f69ab786"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Joystick Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""5330fcab-ab10-4418-b31f-0ce7e16e38af"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Joystick Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""b631d4c4-1485-410f-8ffb-d1305ceb2272"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Joystick Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""be12e27b-deaa-48bf-bd32-1c8a6d05934d"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Joystick Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""c00cc785-b5a6-43d5-950e-106a89f9bb1a"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BackButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""558ee200-ba82-45ad-b82d-640189cdcf7a"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Push"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""BackMiniGame"",
            ""id"": ""9912c3e9-74e3-4f81-ba83-97feab8eb107"",
            ""actions"": [
                {
                    ""name"": ""Back"",
                    ""type"": ""Button"",
                    ""id"": ""11d156c3-b582-4c90-acc2-bb0f5271b1b4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""0dd55493-cea8-4ffc-9983-bcbccca1a20c"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Movement = m_Gameplay.FindAction("Movement", throwIfNotFound: true);
        m_Gameplay_Interaction = m_Gameplay.FindAction("Interaction", throwIfNotFound: true);
        m_Gameplay_Run = m_Gameplay.FindAction("Run", throwIfNotFound: true);
        // UIRotation
        m_UIRotation = asset.FindActionMap("UIRotation", throwIfNotFound: true);
        m_UIRotation_JoystickRotation = m_UIRotation.FindAction("Joystick Rotation", throwIfNotFound: true);
        m_UIRotation_BackButton = m_UIRotation.FindAction("BackButton", throwIfNotFound: true);
        m_UIRotation_Push = m_UIRotation.FindAction("Push", throwIfNotFound: true);
        // BackMiniGame
        m_BackMiniGame = asset.FindActionMap("BackMiniGame", throwIfNotFound: true);
        m_BackMiniGame_Back = m_BackMiniGame.FindAction("Back", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Movement;
    private readonly InputAction m_Gameplay_Interaction;
    private readonly InputAction m_Gameplay_Run;
    public struct GameplayActions
    {
        private @Controls m_Wrapper;
        public GameplayActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Gameplay_Movement;
        public InputAction @Interaction => m_Wrapper.m_Gameplay_Interaction;
        public InputAction @Run => m_Wrapper.m_Gameplay_Run;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                @Interaction.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteraction;
                @Interaction.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteraction;
                @Interaction.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteraction;
                @Run.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRun;
                @Run.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRun;
                @Run.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRun;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Interaction.started += instance.OnInteraction;
                @Interaction.performed += instance.OnInteraction;
                @Interaction.canceled += instance.OnInteraction;
                @Run.started += instance.OnRun;
                @Run.performed += instance.OnRun;
                @Run.canceled += instance.OnRun;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);

    // UIRotation
    private readonly InputActionMap m_UIRotation;
    private IUIRotationActions m_UIRotationActionsCallbackInterface;
    private readonly InputAction m_UIRotation_JoystickRotation;
    private readonly InputAction m_UIRotation_BackButton;
    private readonly InputAction m_UIRotation_Push;
    public struct UIRotationActions
    {
        private @Controls m_Wrapper;
        public UIRotationActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @JoystickRotation => m_Wrapper.m_UIRotation_JoystickRotation;
        public InputAction @BackButton => m_Wrapper.m_UIRotation_BackButton;
        public InputAction @Push => m_Wrapper.m_UIRotation_Push;
        public InputActionMap Get() { return m_Wrapper.m_UIRotation; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIRotationActions set) { return set.Get(); }
        public void SetCallbacks(IUIRotationActions instance)
        {
            if (m_Wrapper.m_UIRotationActionsCallbackInterface != null)
            {
                @JoystickRotation.started -= m_Wrapper.m_UIRotationActionsCallbackInterface.OnJoystickRotation;
                @JoystickRotation.performed -= m_Wrapper.m_UIRotationActionsCallbackInterface.OnJoystickRotation;
                @JoystickRotation.canceled -= m_Wrapper.m_UIRotationActionsCallbackInterface.OnJoystickRotation;
                @BackButton.started -= m_Wrapper.m_UIRotationActionsCallbackInterface.OnBackButton;
                @BackButton.performed -= m_Wrapper.m_UIRotationActionsCallbackInterface.OnBackButton;
                @BackButton.canceled -= m_Wrapper.m_UIRotationActionsCallbackInterface.OnBackButton;
                @Push.started -= m_Wrapper.m_UIRotationActionsCallbackInterface.OnPush;
                @Push.performed -= m_Wrapper.m_UIRotationActionsCallbackInterface.OnPush;
                @Push.canceled -= m_Wrapper.m_UIRotationActionsCallbackInterface.OnPush;
            }
            m_Wrapper.m_UIRotationActionsCallbackInterface = instance;
            if (instance != null)
            {
                @JoystickRotation.started += instance.OnJoystickRotation;
                @JoystickRotation.performed += instance.OnJoystickRotation;
                @JoystickRotation.canceled += instance.OnJoystickRotation;
                @BackButton.started += instance.OnBackButton;
                @BackButton.performed += instance.OnBackButton;
                @BackButton.canceled += instance.OnBackButton;
                @Push.started += instance.OnPush;
                @Push.performed += instance.OnPush;
                @Push.canceled += instance.OnPush;
            }
        }
    }
    public UIRotationActions @UIRotation => new UIRotationActions(this);

    // BackMiniGame
    private readonly InputActionMap m_BackMiniGame;
    private IBackMiniGameActions m_BackMiniGameActionsCallbackInterface;
    private readonly InputAction m_BackMiniGame_Back;
    public struct BackMiniGameActions
    {
        private @Controls m_Wrapper;
        public BackMiniGameActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Back => m_Wrapper.m_BackMiniGame_Back;
        public InputActionMap Get() { return m_Wrapper.m_BackMiniGame; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BackMiniGameActions set) { return set.Get(); }
        public void SetCallbacks(IBackMiniGameActions instance)
        {
            if (m_Wrapper.m_BackMiniGameActionsCallbackInterface != null)
            {
                @Back.started -= m_Wrapper.m_BackMiniGameActionsCallbackInterface.OnBack;
                @Back.performed -= m_Wrapper.m_BackMiniGameActionsCallbackInterface.OnBack;
                @Back.canceled -= m_Wrapper.m_BackMiniGameActionsCallbackInterface.OnBack;
            }
            m_Wrapper.m_BackMiniGameActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Back.started += instance.OnBack;
                @Back.performed += instance.OnBack;
                @Back.canceled += instance.OnBack;
            }
        }
    }
    public BackMiniGameActions @BackMiniGame => new BackMiniGameActions(this);
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    public interface IGameplayActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnInteraction(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
    }
    public interface IUIRotationActions
    {
        void OnJoystickRotation(InputAction.CallbackContext context);
        void OnBackButton(InputAction.CallbackContext context);
        void OnPush(InputAction.CallbackContext context);
    }
    public interface IBackMiniGameActions
    {
        void OnBack(InputAction.CallbackContext context);
    }
}
