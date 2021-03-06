// GENERATED AUTOMATICALLY FROM 'Assets/Atlas/Input/Controls.inputactions'

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
            ""name"": ""CharacterController"",
            ""id"": ""e710bc09-230b-4dd4-aaeb-808fc24c5824"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""13a8a0f9-27b5-47fb-b60e-1206765b1156"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""c059663c-5a2b-48e9-9757-4ebd026de47c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""3f6cc187-f6d6-4200-ba3c-f29766f6f906"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""90efcdaa-be25-4abd-87f3-5dc259e76b97"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CameraInput"",
                    ""type"": ""Value"",
                    ""id"": ""a6051a74-2aa3-4969-bda0-c434dd5a7f80"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""JumpHeld"",
                    ""type"": ""Value"",
                    ""id"": ""55612fb2-bb44-4810-9c33-334e34b36fbe"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RestartGame"",
                    ""type"": ""Button"",
                    ""id"": ""f7c3fc8b-abf9-463f-8ccb-e2f73d161b2b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""e22cb466-16a1-40dd-b9ea-298bd5f1bbe4"",
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
                    ""id"": ""01230ced-c5dc-4314-aef4-f1f676f08211"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""14ff030a-54b0-487d-b675-551097933b9d"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""b99d2301-a284-4482-b436-de595a68112f"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""238f448a-b819-46a0-8549-fe78b7fac926"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""6751a9f5-9414-499a-b21c-9183e36417a8"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": ""Controller"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1c0c9727-f70d-4726-bc60-0e8ffc3e9db6"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ebb94dc1-4140-4c77-b5b9-bc9eee0647e0"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""751b8133-52f1-4102-b47c-2bb054f7189d"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""01e00014-48bd-4937-8c0c-9cd439df5524"",
                    ""path"": ""<Gamepad>/leftStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4890d427-4b73-435f-9933-caa18d0ca714"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""63dcaa04-caa5-48a3-a978-1401e682d178"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0b9a9fcb-0460-4610-964c-a258c924536a"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""CameraInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9a8a2f46-8fe8-4260-9bb6-a70697f9aeb9"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""CameraInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""37084ce9-94fe-4431-8716-82c85a4df483"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""JumpHeld"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1d530e41-e50e-410b-b118-c3caf5df1538"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""JumpHeld"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2d749231-9603-409c-a7d9-3ea43aac9dec"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""RestartGame"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4518a754-6916-49b7-9e3b-003b748f03ed"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""RestartGame"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""KeyboardAndMouse"",
            ""bindingGroup"": ""KeyboardAndMouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Controller"",
            ""bindingGroup"": ""Controller"",
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
        // CharacterController
        m_CharacterController = asset.FindActionMap("CharacterController", throwIfNotFound: true);
        m_CharacterController_Movement = m_CharacterController.FindAction("Movement", throwIfNotFound: true);
        m_CharacterController_Jump = m_CharacterController.FindAction("Jump", throwIfNotFound: true);
        m_CharacterController_Run = m_CharacterController.FindAction("Run", throwIfNotFound: true);
        m_CharacterController_Interact = m_CharacterController.FindAction("Interact", throwIfNotFound: true);
        m_CharacterController_CameraInput = m_CharacterController.FindAction("CameraInput", throwIfNotFound: true);
        m_CharacterController_JumpHeld = m_CharacterController.FindAction("JumpHeld", throwIfNotFound: true);
        m_CharacterController_RestartGame = m_CharacterController.FindAction("RestartGame", throwIfNotFound: true);
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

    // CharacterController
    private readonly InputActionMap m_CharacterController;
    private ICharacterControllerActions m_CharacterControllerActionsCallbackInterface;
    private readonly InputAction m_CharacterController_Movement;
    private readonly InputAction m_CharacterController_Jump;
    private readonly InputAction m_CharacterController_Run;
    private readonly InputAction m_CharacterController_Interact;
    private readonly InputAction m_CharacterController_CameraInput;
    private readonly InputAction m_CharacterController_JumpHeld;
    private readonly InputAction m_CharacterController_RestartGame;
    public struct CharacterControllerActions
    {
        private @Controls m_Wrapper;
        public CharacterControllerActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_CharacterController_Movement;
        public InputAction @Jump => m_Wrapper.m_CharacterController_Jump;
        public InputAction @Run => m_Wrapper.m_CharacterController_Run;
        public InputAction @Interact => m_Wrapper.m_CharacterController_Interact;
        public InputAction @CameraInput => m_Wrapper.m_CharacterController_CameraInput;
        public InputAction @JumpHeld => m_Wrapper.m_CharacterController_JumpHeld;
        public InputAction @RestartGame => m_Wrapper.m_CharacterController_RestartGame;
        public InputActionMap Get() { return m_Wrapper.m_CharacterController; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CharacterControllerActions set) { return set.Get(); }
        public void SetCallbacks(ICharacterControllerActions instance)
        {
            if (m_Wrapper.m_CharacterControllerActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_CharacterControllerActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_CharacterControllerActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_CharacterControllerActionsCallbackInterface.OnMovement;
                @Jump.started -= m_Wrapper.m_CharacterControllerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_CharacterControllerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_CharacterControllerActionsCallbackInterface.OnJump;
                @Run.started -= m_Wrapper.m_CharacterControllerActionsCallbackInterface.OnRun;
                @Run.performed -= m_Wrapper.m_CharacterControllerActionsCallbackInterface.OnRun;
                @Run.canceled -= m_Wrapper.m_CharacterControllerActionsCallbackInterface.OnRun;
                @Interact.started -= m_Wrapper.m_CharacterControllerActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_CharacterControllerActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_CharacterControllerActionsCallbackInterface.OnInteract;
                @CameraInput.started -= m_Wrapper.m_CharacterControllerActionsCallbackInterface.OnCameraInput;
                @CameraInput.performed -= m_Wrapper.m_CharacterControllerActionsCallbackInterface.OnCameraInput;
                @CameraInput.canceled -= m_Wrapper.m_CharacterControllerActionsCallbackInterface.OnCameraInput;
                @JumpHeld.started -= m_Wrapper.m_CharacterControllerActionsCallbackInterface.OnJumpHeld;
                @JumpHeld.performed -= m_Wrapper.m_CharacterControllerActionsCallbackInterface.OnJumpHeld;
                @JumpHeld.canceled -= m_Wrapper.m_CharacterControllerActionsCallbackInterface.OnJumpHeld;
                @RestartGame.started -= m_Wrapper.m_CharacterControllerActionsCallbackInterface.OnRestartGame;
                @RestartGame.performed -= m_Wrapper.m_CharacterControllerActionsCallbackInterface.OnRestartGame;
                @RestartGame.canceled -= m_Wrapper.m_CharacterControllerActionsCallbackInterface.OnRestartGame;
            }
            m_Wrapper.m_CharacterControllerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Run.started += instance.OnRun;
                @Run.performed += instance.OnRun;
                @Run.canceled += instance.OnRun;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @CameraInput.started += instance.OnCameraInput;
                @CameraInput.performed += instance.OnCameraInput;
                @CameraInput.canceled += instance.OnCameraInput;
                @JumpHeld.started += instance.OnJumpHeld;
                @JumpHeld.performed += instance.OnJumpHeld;
                @JumpHeld.canceled += instance.OnJumpHeld;
                @RestartGame.started += instance.OnRestartGame;
                @RestartGame.performed += instance.OnRestartGame;
                @RestartGame.canceled += instance.OnRestartGame;
            }
        }
    }
    public CharacterControllerActions @CharacterController => new CharacterControllerActions(this);
    private int m_KeyboardAndMouseSchemeIndex = -1;
    public InputControlScheme KeyboardAndMouseScheme
    {
        get
        {
            if (m_KeyboardAndMouseSchemeIndex == -1) m_KeyboardAndMouseSchemeIndex = asset.FindControlSchemeIndex("KeyboardAndMouse");
            return asset.controlSchemes[m_KeyboardAndMouseSchemeIndex];
        }
    }
    private int m_ControllerSchemeIndex = -1;
    public InputControlScheme ControllerScheme
    {
        get
        {
            if (m_ControllerSchemeIndex == -1) m_ControllerSchemeIndex = asset.FindControlSchemeIndex("Controller");
            return asset.controlSchemes[m_ControllerSchemeIndex];
        }
    }
    public interface ICharacterControllerActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnCameraInput(InputAction.CallbackContext context);
        void OnJumpHeld(InputAction.CallbackContext context);
        void OnRestartGame(InputAction.CallbackContext context);
    }
}
