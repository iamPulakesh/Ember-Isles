using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ObstacleData))]
public class ObstacleEditor : Editor
{
    private bool showGrid = true;

    public override void OnInspectorGUI()
    {
        ObstacleData obstacleData = (ObstacleData)target;

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Obstacle Grid", EditorStyles.boldLabel);

        showGrid = EditorGUILayout.Toggle("Show Grid", showGrid);

        if (showGrid)
        {
            EditorGUI.indentLevel++;
            for (int i = 0; i < obstacleData.obstacleGrid.GetLength(0); i++)
            {
                EditorGUILayout.BeginHorizontal();
                for (int j = 0; j < obstacleData.obstacleGrid.GetLength(1); j++)
                {
                    bool isObstacle = obstacleData.obstacleGrid[i, j];
                    bool newIsObstacle = EditorGUILayout.Toggle(isObstacle, GUILayout.Width(20));
                   if (newIsObstacle != isObstacle)
                    {
                       obstacleData.obstacleGrid[i, j] = newIsObstacle;
                        
                   }
                }
                EditorGUILayout.EndHorizontal();
            }
            EditorGUI.indentLevel--;
        }

        if (GUILayout.Button("Reset Grid"))
        {
            obstacleData.obstacleGrid = new bool[10, 10];
            
        }

        if (GUI.changed)
        {
            EditorUtility.SetDirty(obstacleData);
        }
    }

}
