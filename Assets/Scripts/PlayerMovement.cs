using UnityEngine;

public class PlayerMovement : Movement
{
    private PlayerAnimation playerAnimation; // Reference to the PlayerAnimation script

    protected override void Start()
    {
        moveSpeed = 5f; // Set move speed for the player
        base.Start();
        playerAnimation = GetComponent<PlayerAnimation>(); // Get the PlayerAnimation component
    }

    protected override void OnPositionSelected(Vector3 position)
    {
        // Set the animation direction based on movement
        playerAnimation.SetDirection(position);
    }
}
