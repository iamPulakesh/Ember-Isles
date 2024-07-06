using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject EnemyPrefab; // Reference to the player prefab
    public int startX = 6; // X coordinate of the starting tile
    public int startZ = 4; // Z coordinate of the starting tile
    public float cubeSize = 1.0f; // Size of each cube
    public float spacing = 0.1f; // Space between cubes
    public Vector3 EnemyScale = new Vector3(0.5f, 0.5f, 0.5f); // Scale of the player

    void Start()
    {
        PlaceEnemyAtTile(startX, startZ);
    }

    void PlaceEnemyAtTile(int x, int z)
    {
        Vector3 position = new Vector3(x * (cubeSize + spacing), 0.5f, z * (cubeSize + spacing));
        // Apply the desired isometric rotation
        Quaternion rotation = Quaternion.Euler(0, 90f, 0);
        GameObject enemy = Instantiate(EnemyPrefab, position, rotation);
        enemy.transform.localScale = EnemyScale; // Set the scale of the player
    }
}
