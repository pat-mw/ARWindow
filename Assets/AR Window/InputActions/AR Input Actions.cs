// GENERATED AUTOMATICALLY FROM 'Assets/AR Window/InputActions/AR Input Actions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @ARInputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @ARInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""AR Input Actions"",
    ""maps"": [
        {
            ""name"": ""Touchscreen"",
            ""id"": ""fa1446f9-66f3-43b9-91c6-d034dcaa7435"",
            ""actions"": [
                {
                    ""name"": ""tap"",
                    ""type"": ""PassThrough"",
                    ""id"": ""66743e3d-5228-4d89-a82c-4a2195ef0bbf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""touchPos"",
                    ""type"": ""Value"",
                    ""id"": ""7c549c75-b9d9-4268-88a3-121b807a93f0"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""23a66a49-de93-4adb-97c1-74bbdf687a2e"",
                    ""path"": ""<Touchscreen>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""tap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""257928fb-ea5f-40ea-8666-a96eb35bdeed"",
                    ""path"": ""<Mouse>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""tap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3eb3774f-3958-410a-bc1c-3bca744fb09f"",
                    ""path"": ""<Touchscreen>/primaryTouch/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""touchPos"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Touchscreen
        m_Touchscreen = asset.FindActionMap("Touchscreen", throwIfNotFound: true);
        m_Touchscreen_tap = m_Touchscreen.FindAction("tap", throwIfNotFound: true);
        m_Touchscreen_touchPos = m_Touchscreen.FindAction("touchPos", throwIfNotFound: true);
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

    // Touchscreen
    private readonly InputActionMap m_Touchscreen;
    private ITouchscreenActions m_TouchscreenActionsCallbackInterface;
    private readonly InputAction m_Touchscreen_tap;
    private readonly InputAction m_Touchscreen_touchPos;
    public struct TouchscreenActions
    {
        private @ARInputActions m_Wrapper;
        public TouchscreenActions(@ARInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @tap => m_Wrapper.m_Touchscreen_tap;
        public InputAction @touchPos => m_Wrapper.m_Touchscreen_touchPos;
        public InputActionMap Get() { return m_Wrapper.m_Touchscreen; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TouchscreenActions set) { return set.Get(); }
        public void SetCallbacks(ITouchscreenActions instance)
        {
            if (m_Wrapper.m_TouchscreenActionsCallbackInterface != null)
            {
                @tap.started -= m_Wrapper.m_TouchscreenActionsCallbackInterface.OnTap;
                @tap.performed -= m_Wrapper.m_TouchscreenActionsCallbackInterface.OnTap;
                @tap.canceled -= m_Wrapper.m_TouchscreenActionsCallbackInterface.OnTap;
                @touchPos.started -= m_Wrapper.m_TouchscreenActionsCallbackInterface.OnTouchPos;
                @touchPos.performed -= m_Wrapper.m_TouchscreenActionsCallbackInterface.OnTouchPos;
                @touchPos.canceled -= m_Wrapper.m_TouchscreenActionsCallbackInterface.OnTouchPos;
            }
            m_Wrapper.m_TouchscreenActionsCallbackInterface = instance;
            if (instance != null)
            {
                @tap.started += instance.OnTap;
                @tap.performed += instance.OnTap;
                @tap.canceled += instance.OnTap;
                @touchPos.started += instance.OnTouchPos;
                @touchPos.performed += instance.OnTouchPos;
                @touchPos.canceled += instance.OnTouchPos;
            }
        }
    }
    public TouchscreenActions @Touchscreen => new TouchscreenActions(this);
    public interface ITouchscreenActions
    {
        void OnTap(InputAction.CallbackContext context);
        void OnTouchPos(InputAction.CallbackContext context);
    }
}
