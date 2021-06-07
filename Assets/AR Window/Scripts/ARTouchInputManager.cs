using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using System.Collections.Generic;

[DefaultExecutionOrder(-1)]
public class ARTouchInputManager : MonoBehaviour
{
    public static ARTouchInputManager Instance;

    private ARInputActions Inputs;

    // Event handlers
    public delegate void StartTouchEvent(Vector2 position);
    public event StartTouchEvent OnStartTouch;
    public delegate void EndTouchEvent(Vector2 position);
    public event EndTouchEvent OnEndTouch;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Debug.LogError($"ERROR: more than one AR Input Manager found in the scene. Destroying {this.name}");
            Destroy(this);
        }

        Inputs = new ARInputActions();    
    }

    private void Start()
    {
        // handle the callbacks
        Inputs.Touchscreen.tap.started += ctx => StartTouch(ctx);
        Inputs.Touchscreen.tap.canceled += ctx => EndTouch(ctx);
    }

    private void StartTouch(InputAction.CallbackContext context)
    {
        Debug.Log($"Touch started: {Inputs.Touchscreen.touchPos.ReadValue<Vector2>()}");
        
        // if we have methods currently subscribed to this event
        if (OnStartTouch != null)
        {
            if (!IsPointerOverUIObject())
            {
                OnStartTouch(Inputs.Touchscreen.touchPos.ReadValue<Vector2>());
            }
        }
    }

    private void EndTouch(InputAction.CallbackContext context)
    {
        Debug.Log($"Touch ended: {Inputs.Touchscreen.touchPos.ReadValue<Vector2>()}");

        // if we have methods currently subscribed to this event
        if (OnEndTouch != null)
        {
            if (!IsPointerOverUIObject())
            {
                OnEndTouch(Inputs.Touchscreen.touchPos.ReadValue<Vector2>());
            }
        }
    }

    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Inputs.Touchscreen.touchPos.ReadValue<Vector2>().x, Inputs.Touchscreen.touchPos.ReadValue<Vector2>().y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }

    private void OnEnable()
    {
        Inputs.Enable();
    }

    private void OnDisable()
    {
        Inputs.Disable();
    }
}
