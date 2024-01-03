using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.InputSystem.HID;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private InputActionAsset inputs;
    [SerializeField]
    private InputActionReference primaryTouch;
    [SerializeField]
    private InputActionReference primaryTap;    
    [SerializeField]
    private InputActionReference primaryTouchPoint;

    // Start is called before the first frame update
    void Start()
    {
        inputs.Enable();
        //primaryTouch.action.performed += Tap;
        primaryTap.action.performed += Tap;
    }

    private void Awake()
    {
        EnhancedTouchSupport.Enable();
    }

    private void Tap(InputAction.CallbackContext context)
    {
        Debug.Log("Tap!");
        var pos = primaryTouchPoint.action.ReadValue<Vector2>();
        var ray = Camera.main.ScreenPointToRay(pos);

        if (Physics.Raycast(ray, out var hit))
        {
            Transform objectHit = hit.transform;
            if (objectHit != null) {
                var card = objectHit.GetComponent<DioramaCard>();
                if (card != null)
                    card.MoveToTarget();
            }
        }
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 100, true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Touch.activeFingers.Count == 1)
        {
            Touch activeTouch = Touch.activeFingers[0].currentTouch;
            Debug.Log($"Phase: {activeTouch.phase} | Position: {activeTouch.startScreenPosition}");
        }
    }
}
