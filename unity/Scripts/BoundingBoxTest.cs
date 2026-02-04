using UnityEngine;
public class BoundingBoxTest : MonoBehaviour
{
    private static Texture2D _boxTexture;
    void OnGUI()
    {
        if (_boxTexture == null)
        {
            _boxTexture = new Texture2D(1, 1);
            _boxTexture.SetPixel(0, 0, Color.red);
            _boxTexture.Apply();
        }
        Rect box = new Rect(100, 100, 200, 150);
        GUI.DrawTexture(box, _boxTexture);
        Debug.Log("Drawing red box...");
    }
}