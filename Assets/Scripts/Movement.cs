using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed; // Movement speed of the character
    protected Vector3 targetPosition; // Target position for movement
    protected bool isMoving = false; // Is the character currently moving?

    protected virtual void Start()
    {
        targetPosition = transform.position; // Initialize target position to current position
    }

    protected virtual void Update()
    {
        HandleMovement();

        // Move the character towards the target position
        if (isMoving)
        {
            float step = moveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

            if (Vector3.Distance(transform.position, targetPosition) < 0.05f)
            {
                isMoving = false; // Stop moving when the target position is reached
            }
        }
    }

    protected void HandleMovement()
    {
        // Check for mouse click
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Move towards the clicked position
                MoveToPosition(hit.point);
                OnPositionSelected(hit.point);
            }
        }
    }

    protected virtual void MoveToPosition(Vector3 newPosition)
    {
        targetPosition = new Vector3(newPosition.x, transform.position.y, newPosition.z);
        isMoving = true;
    }

    // This method can be overridden by derived classes to add specific behavior when a position is selected
    protected virtual void OnPositionSelected(Vector3 position)
    {
    }
}
