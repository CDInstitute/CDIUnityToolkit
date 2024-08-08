// Gaze Input Module by Peter Koch <peterept@gmail.com>
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.InputSystem;

// To use:
// 1. Drag onto your EventSystem game object.
// 2. Disable any other Input Modules (eg: StandaloneInputModule & TouchInputModule) as they will fight over selections.
// 3. Make sure your Canvas is in world space and has a GraphicRaycaster (should by default).
// 4. If you have multiple cameras then make sure to drag your VR (center eye) camera into the canvas.
public class GazeInputModule : PointerInputModule
{
    public enum Mode { Click = 0, Gaze };
    public Mode mode;

    [Header("Submit Settings")]
    public InputActionReference submitAction = null;
    
    [Header("Gaze Settings")]
    public float gazeTimeInSeconds = 2f;

    private PointerEventData pointerEventData;
    private GameObject currentLookAtHandler;
    private float currentLookAtHandlerClickTime;

    public override void Process()
    {
        HandleLook();
        HandleSelection();
    }
    
    protected override void OnEnable()
    {
        base.OnEnable();
        
        if(submitAction != null)
        {
            submitAction.action.Enable();
        }
    }
    
    protected override void OnDisable()
    {
        base.OnDisable();
        
        if(submitAction != null)
        {
            submitAction.action.Disable();
        }
    }

    private void HandleLook()
    {
        pointerEventData ??= new PointerEventData(eventSystem);
        
        // fake a pointer always being at the center of the screen
        pointerEventData.position = new Vector2(Screen.width / 2.0f, Screen.height / 2.0f);
        pointerEventData.delta = Vector2.zero;
        var raycastResults = new List<RaycastResult>();
        eventSystem.RaycastAll(pointerEventData, raycastResults);
        pointerEventData.pointerCurrentRaycast = FindFirstRaycast(raycastResults);
        ProcessMove(pointerEventData);
    }

    private void HandleSelection()
    {
        if (pointerEventData.pointerEnter != null)
        {
            // if the ui receiver has changed, reset the gaze delay timer
            var handler = ExecuteEvents.GetEventHandler<IPointerClickHandler>(pointerEventData.pointerEnter);
            if (currentLookAtHandler != handler)
            {
                currentLookAtHandler = handler;
                currentLookAtHandlerClickTime = Time.realtimeSinceStartup + gazeTimeInSeconds;
            }

            // if we have a handler and it's time to click, do it now
            if (currentLookAtHandler != null &&
                (mode == Mode.Gaze && Time.realtimeSinceStartup > currentLookAtHandlerClickTime) ||
                (mode == Mode.Click && submitAction != null && submitAction.action.triggered))
            {
                ExecuteEvents.ExecuteHierarchy(currentLookAtHandler, pointerEventData, ExecuteEvents.pointerClickHandler);
                currentLookAtHandlerClickTime = float.MaxValue;
            }
        }
        else
        {
            currentLookAtHandler = null;
        }
    }
}