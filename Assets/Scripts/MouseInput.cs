using UnityEngine;
using UnityEngine.UI;

public class MouseInput : MonoBehaviour
{
    public Text InfoText; 

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); /// create a ray from the camera through the mouse position
        RaycastHit hit; 

        // Check if the ray intersects with a collider in the scene.
        if (Physics.Raycast(ray, out hit))
        {
            Info tileInfo = hit.collider.GetComponent<Info>(); // get the Info component from the object hit by the ray
            if (tileInfo != null)
            {
                InfoText.text = $"Tile Position: ({tileInfo.x}, {tileInfo.y})";// Update the UI Text with tile coordinates
            }
            else
            {
               InfoText.text = "";
            }
        }
        else
        {
            InfoText.text = "";
        }
    }
}
