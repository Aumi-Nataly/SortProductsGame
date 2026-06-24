using UnityEngine;
using UnityEngine.InputSystem;

public class ClickManager : MonoBehaviour
{
    [SerializeField]
    private Camera cam;
    [SerializeField]
    private float moveSpeed = 10f;

    private Vector2 startOffset = Vector2.zero;
    private GameObject draggedObject = null;
    private InputSystem_Actions inputActions;

    private void Awake()
    {
        inputActions = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        inputActions.Enable();
        inputActions.Gameplay.Click.performed += ClickPerformed;
        inputActions.Gameplay.Click.canceled += ClickCanceled;
    }

    private void OnDisable()
    {
        inputActions.Gameplay.Click.performed -= ClickPerformed;
        inputActions.Gameplay.Click.canceled -= ClickCanceled;
        inputActions.Disable();
    }

    private void ClickCanceled(InputAction.CallbackContext context)
    {
        draggedObject = null; 
        Debug.Log("Объект отпущен");
    }


    private void ClickPerformed(InputAction.CallbackContext context)
    {
        Vector2 mousePos = inputActions.Gameplay.MovePoint.ReadValue<Vector2>();
        Vector2 point = cam.ScreenToWorldPoint(mousePos);
        int layerMask = LayerMask.GetMask("Product");

        Collider2D hit = Physics2D.OverlapPoint(point, layerMask);

        if (hit != null)
        {
            Debug.Log("Клик по: " + hit.name);
            draggedObject = hit.gameObject;
            startOffset = (Vector2)draggedObject.transform.position - point;
        }
    }

    private void Update()
    {
        if (draggedObject != null)
        {
            Vector2 mousePos = inputActions.Gameplay.MovePoint.ReadValue<Vector2>();
            Vector2 targetPosition = cam.ScreenToWorldPoint(mousePos); 
            draggedObject.transform.position = targetPosition;         
        }
    }


}
