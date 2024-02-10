using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AdaptivePerformance;
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
    [SerializeField]
    private InputActionReference dragAction;


    // Rotation
    [SerializeField]
    private Transform cameraPivot;
    public float rotationSpeed = 1f;
    public float rotationFactor = 1f;
    private Vector2 lastTouchPosition;
    private Vector3 targetRotation;

    // Zoom


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

    // Card touches
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
        //Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 100, true);
    }

    // Update is called once per frame
    void Update()
    {
        // Rotation
        if (Touch.activeFingers.Count == 1)
        {
            Vector2 currentTouchPosition = primaryTouchPoint.action.ReadValue<Vector2>();

            if (lastTouchPosition != Vector2.zero)
            {
                float deltaX = currentTouchPosition.x - lastTouchPosition.x;
                float deltaY = currentTouchPosition.y - lastTouchPosition.y;

                Debug.Log(deltaX);


                targetRotation.x = Mathf.Clamp(targetRotation.x + deltaX * rotationFactor, -160, 160);
                targetRotation.y = Mathf.Clamp(targetRotation.y - deltaY * rotationFactor, -10, 40);              

            }

            lastTouchPosition = currentTouchPosition;
        }
        else
        {
            lastTouchPosition = Vector2.zero;
        }

        var rotation = Quaternion.Lerp(cameraPivot.rotation, Quaternion.Euler(targetRotation.y, targetRotation.x, 0), Time.deltaTime * rotationSpeed).eulerAngles;
        rotation.z = 0f;
        cameraPivot.rotation = Quaternion.Euler(rotation);

        // Zoom
        if (Touch.activeFingers.Count == 2)
        {

        }

    }
}
