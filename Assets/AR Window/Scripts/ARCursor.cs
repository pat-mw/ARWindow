using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using ScriptableObjectArchitecture;

public class ARCursor : MonoBehaviour
{
    // external references
    [Header("Prefab")]
    [SerializeField] GameObject objectToPlace;
    [Header("Events and Variables")]
    [SerializeField] BoolGameEvent toggleCursorEvent;
    [SerializeField] BoolReference useCursor;

    // local variables
    private GameObject cursorSprite;
    private ARRaycastManager raycastManager;
    private ARTouchInputManager InputManager;
    private Vector2 cursorScreenPos;
    private List<ARRaycastHit> hits;

    private void Awake()
    {
        // Input manager
        InputManager = ARTouchInputManager.Instance;

        // Raycast manager
        raycastManager = SessionOrigin.Instance.GetComponent<ARRaycastManager>();

        // local references
        cursorSprite = transform.GetChild(0).gameObject;
        cursorScreenPos = Camera.main.ViewportToScreenPoint(new Vector2(0.5f, 0.5f));
        hits = new List<ARRaycastHit>();
    }

    private void Start()
    {
        // suscribe to Scriptable Object Events
        toggleCursorEvent.AddListener(ToggleCursor);

        // subscribe to input events
        InputManager.OnStartTouch += PlaceObject;
    }

    public void ToggleCursor(bool _useCursor)
    {
        Debug.Log("toggling cursor | Cursor Active: " + _useCursor);
        cursorSprite.SetActive(_useCursor);
    }

    private void PlaceObject(Vector2 touchPos)
    {
        Debug.Log("tap detected! - placing object");

        if (useCursor.Value)
        {
            // instantiate at the cursor position
            Instantiate(objectToPlace, transform.position, transform.rotation);
        }
        else
        {
            // instantiate at the tap position
            raycastManager.Raycast(touchPos, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes);
            if (hits.Count > 0)
            {
                GameObject.Instantiate(objectToPlace, hits[0].pose.position, hits[0].pose.rotation);
            }
        }
    }

    private void Update()
    {
        if (useCursor.Value)
        {
            UpdateCursor();
        }
    }

    private void UpdateCursor()
    {

        raycastManager.Raycast(cursorScreenPos, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes);
        if (hits.Count > 0)
        {
            transform.position = hits[0].pose.position;
            transform.rotation = hits[0].pose.rotation;
        }
    }
}
