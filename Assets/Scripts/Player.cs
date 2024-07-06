using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject playerPrefab; // Reference to the player prefab
    public int startX = 0; // X coordinate of the starting tile
    public int startZ = 0; // Z coordinate of the starting tile
    public float cubeSize = 1.0f; // Size of each cube
    public float spacing = 0.1f; // Space between cubes
    public Vector3 playerScale = new Vector3(2.4f, 2.4f, 2.4f); // Scale of the player

    void Start()
    {
        PlacePlayerAtTile(startX, startZ);
    }

    void PlacePlayerAtTile(int x, int z)
    {
        Vector3 position = new Vector3(x * (cubeSize + spacing), 1.1f, z * (cubeSize + spacing));
        // Apply the desired isometric rotation
        Quaternion rotation = Quaternion.Euler(0, 45f, 0);
        GameObject player = Instantiate(playerPrefab, position, rotation);
        player.transform.localScale = playerScale; // Set the scale of the player
    }
}
