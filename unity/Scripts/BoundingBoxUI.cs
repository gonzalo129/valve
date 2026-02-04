using UnityEngine;
using UnityEngine.UI;
public class BoundingBoxUI : MonoBehaviour
{
    public RectTransform boundingBoxRect;
    void Start()
    {
        // Example bounding box at (100, 100) with size 200x150
        SetBoundingBox(new Rect(100, 100, 200, 150));
    }
    public void SetBoundingBox(Rect screenRect)
    {
        boundingBoxRect.anchoredPosition = new Vector2(screenRect.x, -screenRect.y);
        boundingBoxRect.sizeDelta = new Vector2(screenRect.width, screenRect.height);
    }
}