using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;

    //animation clip names should be consistent between these and the Animator's state machine.
    public string[] staticDirections = { "Static N", "Static NW", "Static W", "Static SW", "Static S", "Static SE", "Static E", "Static NE" };
    public string[] runDirections = { "Run N", "Run NW", "Run W", "Run SW", "Run S", "Run SE", "Run E", "Run NE" };

    int lastDirection; 

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void SetDirection(Vector3 targetPosition)
    {
        Vector3 directionVector = (targetPosition - transform.position).normalized;
        string[] directionArray;

        if (directionVector.magnitude < 0.01f)
        {
            directionArray = staticDirections;
            UpdateAnimation(false); // Update animation to static
        }
        else
        {
            directionArray = runDirections;
            lastDirection = DirectionToIndex(directionVector);
            UpdateAnimation(true); // Update animation to running
        }

        anim.Play(directionArray[lastDirection]);
    }

    private void UpdateAnimation(bool isMoving)
    {
        anim.SetBool("IsMoving", isMoving); // Set the IsMoving parameter in the Animator
    }

    private int DirectionToIndex(Vector3 directionVector)
    {
        float angle = Vector3.SignedAngle(Vector3.forward, directionVector, Vector3.up);
        angle += 360f / 16f; // Offset angle to align with 16 directions (360/16 = 22.5)

        if (angle < 0)
        {
            angle += 360;
        }

        float step = 360f / 8f; // 8 directions (0, 45, 90, 135, 180, 225, 270, 315)
        float halfStep = step / 2f;

        int index = Mathf.FloorToInt((angle + halfStep) / step) % 8; // Determine the index based on which section the angle falls into.

        return index;
    }
}
