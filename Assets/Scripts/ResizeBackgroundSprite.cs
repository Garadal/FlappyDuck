using UnityEngine;
using UnityEngine.UI;

public class ResizeBackgroundSprite : MonoBehaviour
{
    void Start()
    {
        // Get the height of the screen
        float screenHeight = Screen.height;

        // Get the child count of the horizontal layout group
        int childCount = transform.childCount;

        // Loop through all child gameobjects of the horizontal layout group
        for (int i = 0; i < childCount; i++)
        {
            // Get the child gameobject and its rect transform component
            GameObject child = transform.GetChild(i).gameObject;
            RectTransform rectTransform = child.GetComponent<RectTransform>();

            // Set the height of the rect transform to match the screen height
            rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, screenHeight);
        }
    }
}
