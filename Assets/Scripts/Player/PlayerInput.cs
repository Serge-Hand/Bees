// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Player/PlayerInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""PlayerMap"",
            ""id"": ""72281137-32b6-4e51-a733-70b1030233cc"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""aec9aeff-f5b8-4f03-9c12-bdbd53cc45b9"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c9ecce91-bd9d-4175-a25f-8e1a19091c56"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""TouchMap"",
            ""id"": ""dbdddb00-7e97-4094-a93c-d8d11bc701e3"",
            ""actions"": [
                {
                    ""name"": ""Touch"",
                    ""type"": ""Button"",
                    ""id"": ""d0676f4a-2fc6-4ad4-945d-d3166092702e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TouchPosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""ed7d5db6-77f4-41eb-b74d-165c855568cd"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""505ea463-0144-4c7f-8d56-259de4262522"",
                    ""path"": ""<Touchscreen>/primaryTouch/press"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Touch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""12740a3d-504b-4b33-8a34-4a2d5cd524c2"",
                    ""path"": ""<Touchscreen>/primaryTouch/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerMap
        m_PlayerMap = asset.FindActionMap("PlayerMap", throwIfNotFound: true);
        m_PlayerMap_Move = m_PlayerMap.FindAction("Move", throwIfNotFound: true);
        // TouchMap
        m_TouchMap = asset.FindActionMap("TouchMap", throwIfNotFound: true);
        m_TouchMap_Touch = m_TouchMap.FindAction("Touch", throwIfNotFound: true);
        m_TouchMap_TouchPosition = m_TouchMap.FindAction("TouchPosition", throwIfNotFound: true);
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

    // PlayerMap
    private readonly InputActionMap m_PlayerMap;
    private IPlayerMapActions m_PlayerMapActionsCallbackInterface;
    private readonly InputAction m_PlayerMap_Move;
    public struct PlayerMapActions
    {
        private @PlayerInput m_Wrapper;
        public PlayerMapActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_PlayerMap_Move;
        public InputActionMap Get() { return m_Wrapper.m_PlayerMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerMapActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerMapActions instance)
        {
            if (m_Wrapper.m_PlayerMapActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnMove;
            }
            m_Wrapper.m_PlayerMapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
            }
        }
    }
    public PlayerMapActions @PlayerMap => new PlayerMapActions(this);

    // TouchMap
    private readonly InputActionMap m_TouchMap;
    private ITouchMapActions m_TouchMapActionsCallbackInterface;
    private readonly InputAction m_TouchMap_Touch;
    private readonly InputAction m_TouchMap_TouchPosition;
    public struct TouchMapActions
    {
        private @PlayerInput m_Wrapper;
        public TouchMapActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Touch => m_Wrapper.m_TouchMap_Touch;
        public InputAction @TouchPosition => m_Wrapper.m_TouchMap_TouchPosition;
        public InputActionMap Get() { return m_Wrapper.m_TouchMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TouchMapActions set) { return set.Get(); }
        public void SetCallbacks(ITouchMapActions instance)
        {
            if (m_Wrapper.m_TouchMapActionsCallbackInterface != null)
            {
                @Touch.started -= m_Wrapper.m_TouchMapActionsCallbackInterface.OnTouch;
                @Touch.performed -= m_Wrapper.m_TouchMapActionsCallbackInterface.OnTouch;
                @Touch.canceled -= m_Wrapper.m_TouchMapActionsCallbackInterface.OnTouch;
                @TouchPosition.started -= m_Wrapper.m_TouchMapActionsCallbackInterface.OnTouchPosition;
                @TouchPosition.performed -= m_Wrapper.m_TouchMapActionsCallbackInterface.OnTouchPosition;
                @TouchPosition.canceled -= m_Wrapper.m_TouchMapActionsCallbackInterface.OnTouchPosition;
            }
            m_Wrapper.m_TouchMapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Touch.started += instance.OnTouch;
                @Touch.performed += instance.OnTouch;
                @Touch.canceled += instance.OnTouch;
                @TouchPosition.started += instance.OnTouchPosition;
                @TouchPosition.performed += instance.OnTouchPosition;
                @TouchPosition.canceled += instance.OnTouchPosition;
            }
        }
    }
    public TouchMapActions @TouchMap => new TouchMapActions(this);
    public interface IPlayerMapActions
    {
        void OnMove(InputAction.CallbackContext context);
    }
    public interface ITouchMapActions
    {
        void OnTouch(InputAction.CallbackContext context);
        void OnTouchPosition(InputAction.CallbackContext context);
    }
}
