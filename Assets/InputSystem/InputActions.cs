// GENERATED AUTOMATICALLY FROM 'Assets/InputSystem/InputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""PrimaryActions"",
            ""id"": ""a2448b6f-ca88-4037-8b9b-2e11c0c88a3d"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""67559781-04c5-4e9c-a4a9-585842697cad"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MouseRotation"",
                    ""type"": ""Value"",
                    ""id"": ""1e4ae09d-ab4d-4ecf-a160-683256b47ee2"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Horizontal"",
                    ""type"": ""Value"",
                    ""id"": ""fea0609b-ee6d-4df2-b4fd-064c7d9c8664"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Vertical"",
                    ""type"": ""Button"",
                    ""id"": ""4d36c3e0-21c1-4e36-8cf2-293fd1cdf387"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ca7db570-88f2-48bf-9ad5-cc5406ea65a8"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1bf5ba19-6696-493b-8ed7-dd48a75cbf46"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseRotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""03f2d245-dc36-4d66-b23b-d597688fd8a4"",
                    ""path"": ""1DAxis"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""2cfe46bb-1a8c-4339-aea6-291c59202d54"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""0c1f8cf5-bb7a-440d-9952-da85543c5450"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""28d9e638-6c7d-4cdf-a731-5822753f932c"",
                    ""path"": ""1DAxis"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""0b8972d1-59d3-4dc9-8433-b67a534a550b"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""8c655f73-b116-4ae3-8497-d271c3e7c374"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PrimaryActions
        m_PrimaryActions = asset.FindActionMap("PrimaryActions", throwIfNotFound: true);
        m_PrimaryActions_Movement = m_PrimaryActions.FindAction("Movement", throwIfNotFound: true);
        m_PrimaryActions_MouseRotation = m_PrimaryActions.FindAction("MouseRotation", throwIfNotFound: true);
        m_PrimaryActions_Horizontal = m_PrimaryActions.FindAction("Horizontal", throwIfNotFound: true);
        m_PrimaryActions_Vertical = m_PrimaryActions.FindAction("Vertical", throwIfNotFound: true);
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

    // PrimaryActions
    private readonly InputActionMap m_PrimaryActions;
    private IPrimaryActionsActions m_PrimaryActionsActionsCallbackInterface;
    private readonly InputAction m_PrimaryActions_Movement;
    private readonly InputAction m_PrimaryActions_MouseRotation;
    private readonly InputAction m_PrimaryActions_Horizontal;
    private readonly InputAction m_PrimaryActions_Vertical;
    public struct PrimaryActionsActions
    {
        private @InputActions m_Wrapper;
        public PrimaryActionsActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_PrimaryActions_Movement;
        public InputAction @MouseRotation => m_Wrapper.m_PrimaryActions_MouseRotation;
        public InputAction @Horizontal => m_Wrapper.m_PrimaryActions_Horizontal;
        public InputAction @Vertical => m_Wrapper.m_PrimaryActions_Vertical;
        public InputActionMap Get() { return m_Wrapper.m_PrimaryActions; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PrimaryActionsActions set) { return set.Get(); }
        public void SetCallbacks(IPrimaryActionsActions instance)
        {
            if (m_Wrapper.m_PrimaryActionsActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PrimaryActionsActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PrimaryActionsActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PrimaryActionsActionsCallbackInterface.OnMovement;
                @MouseRotation.started -= m_Wrapper.m_PrimaryActionsActionsCallbackInterface.OnMouseRotation;
                @MouseRotation.performed -= m_Wrapper.m_PrimaryActionsActionsCallbackInterface.OnMouseRotation;
                @MouseRotation.canceled -= m_Wrapper.m_PrimaryActionsActionsCallbackInterface.OnMouseRotation;
                @Horizontal.started -= m_Wrapper.m_PrimaryActionsActionsCallbackInterface.OnHorizontal;
                @Horizontal.performed -= m_Wrapper.m_PrimaryActionsActionsCallbackInterface.OnHorizontal;
                @Horizontal.canceled -= m_Wrapper.m_PrimaryActionsActionsCallbackInterface.OnHorizontal;
                @Vertical.started -= m_Wrapper.m_PrimaryActionsActionsCallbackInterface.OnVertical;
                @Vertical.performed -= m_Wrapper.m_PrimaryActionsActionsCallbackInterface.OnVertical;
                @Vertical.canceled -= m_Wrapper.m_PrimaryActionsActionsCallbackInterface.OnVertical;
            }
            m_Wrapper.m_PrimaryActionsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @MouseRotation.started += instance.OnMouseRotation;
                @MouseRotation.performed += instance.OnMouseRotation;
                @MouseRotation.canceled += instance.OnMouseRotation;
                @Horizontal.started += instance.OnHorizontal;
                @Horizontal.performed += instance.OnHorizontal;
                @Horizontal.canceled += instance.OnHorizontal;
                @Vertical.started += instance.OnVertical;
                @Vertical.performed += instance.OnVertical;
                @Vertical.canceled += instance.OnVertical;
            }
        }
    }
    public PrimaryActionsActions @PrimaryActions => new PrimaryActionsActions(this);
    public interface IPrimaryActionsActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnMouseRotation(InputAction.CallbackContext context);
        void OnHorizontal(InputAction.CallbackContext context);
        void OnVertical(InputAction.CallbackContext context);
    }
}
