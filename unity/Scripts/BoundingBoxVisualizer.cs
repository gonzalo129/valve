using UnityEngine;
public class BoundingBoxVisualizer : MonoBehaviour
{
    public Rect boundingBox; // Assign or calculate this each frame
    void OnGUI()
    {
        Rect testBox = new Rect(100, 100, 200, 150); // x, y, width, height
        GUI.color = Color.red;
        GUI.DrawTexture(testBox, Texture2D.whiteTexture);
    }
}