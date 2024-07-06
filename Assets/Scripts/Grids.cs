using UnityEngine;

public class Grids : MonoBehaviour
{
    public int gridSize; // Size of the grid
    public float cubeSize = 1.0f; // Size of each cube
    public float spacing = 0.1f; // Space between cubes
    public GameObject cubePrefab;
   

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    { // Nested loops to iterate over rows and columns
        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                Vector3 position = new Vector3(i * (cubeSize + spacing), 0, j * (cubeSize + spacing)); // for calculating the position for the current cube
                GameObject cube = Instantiate(cubePrefab, position, Quaternion.identity); //cretaing instance of cube from prefab
                cube.name = $"Tile_{i}_{j}";

                Info tileInfo = cube.AddComponent<Info>(); // attach an info component to the cube to store data
                tileInfo.SetTileInfo(i, j);
            }
        }
    }
}
