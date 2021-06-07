using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ScriptableObjectArchitecture;
using UnityEngine.XR.ARFoundation;

public class ARGaze : MonoBehaviour
{
    [Header("Gaze Pointer Sprites")]
    [SerializeField] private Sprite inactiveGazeSprite;
    [SerializeField] private Sprite activeGazeSprite;

    [Header("Events")]
    [SerializeField] private BoolGameEvent gazeActiveEvent;

    private Image gazePointerImage;
    private ARRaycastManager raycastManager;
    private Vector2 cursorScreenPos = new Vector2(0.5f, 0.5f);
    private List<ARRaycastHit> hits;

    private void Awake()
    {
        try
        {
            gazePointerImage = GetComponentInChildren<Image>();
            gazePointerImage.sprite = inactiveGazeSprite;
        }
        catch (Exception ex)
        {

            Debug.Log("Could not find the GazePointer" + ex.Message);
        }

        // Raycast manager
        raycastManager = SessionOrigin.Instance.GetComponent<ARRaycastManager>();

        // gaze raycasting set up
        cursorScreenPos = Camera.main.ViewportToScreenPoint(new Vector2(0.5f, 0.5f));
        hits = new List<ARRaycastHit>();
    }

    private void Start()
    {
        // suscribe to Scriptable Object Events
        gazeActiveEvent.AddListener(toggleGazeActive);

        //// subscribe to input events
        //InputManager.OnStartTouch += PlaceObject;
    }

    private void toggleGazeActive(bool _gazeActive)
    {
        Debug.Log("toggling gaze | Gaze Active: " + _gazeActive);

        if (_gazeActive)
        {
            gazePointerImage.sprite = activeGazeSprite;
        }
        else
        {
            gazePointerImage.sprite = inactiveGazeSprite;
        }
    }

    private void CheckGazeObject()
    {
        raycastManager.Raycast(cursorScreenPos, hits);
        if (hits.Count > 0)
        {
            // What type of thing did we hit?
            Debug.Log($"Raycast hit a {hits[0].hitType}");
        }
    }


}
