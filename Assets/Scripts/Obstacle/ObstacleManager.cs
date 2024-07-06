using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public ObstacleData obstacleData;

    void Start()
    {
        GenerateObstacles();
    }

    void GenerateObstacles()
    {
        // Loop through the obstacle grid dimensions
        for (int i = 0; i < obstacleData.obstacleGrid.GetLength(0); i++)
        {
            for (int j = 0; j < obstacleData.obstacleGrid.GetLength(1); j++)
            {
                if (obstacleData.obstacleGrid[i, j]) // Check if the current grid cell has an obstacle
                { 
                Vector3 position = new Vector3(i * (1.0f + 0.1f), 1f, j * (1.0f + 0.1f));
                Debug.Log($"Generating obstacle at ({i}, {j}) - Position: {position}");

                GameObject obstacle = Instantiate(obstaclePrefab, position, Quaternion.identity);
                obstacle.name = $"Obstacle_{i}_{j}";// Name the instantiated obstacle for easy identification
                }
            }
        }
    }
}
