using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharacterSelectionMenu : MonoBehaviour
{
    public float lerpSpeed = 10f; // Speed at which the images move
    public float selectedScale = 1.5f; // Scale of the selected image
    public float unselectedScale = 1f; // Scale of the unselected images
    public float selectDelay = 0.2f; // Delay between arrow key presses
    public RectTransform content; // The content of the ScrollRect
    public RectTransform[] images; // The images of the characters
    public int selectedIndex = 0; // The currently selected index
    private bool canSelect = true; // Flag to prevent rapid selection

    private void Start()
    {
        // Get all images
        int childCount = content.gameObject.transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            // Get the child object at index i
            GameObject childObject = content.gameObject.transform.GetChild(i).gameObject;
            images[i] = childObject.GetComponent<RectTransform>();
        }
        // Set initial image scales
        for (int i = 0; i < images.Length; i++)
        {
            if (i == selectedIndex)
            {
                images[i].localScale = Vector3.one * selectedScale;
            }
            else
            {
                images[i].localScale = Vector3.one * unselectedScale;
            }
        }
        // Set initial content position
        Vector2 contentPos = content.anchoredPosition;
        contentPos.x = selectedIndex * -images[0].rect.width + (content.rect.width - images[0].rect.width) / 2f;
        content.anchoredPosition = contentPos;
    }
    private void Update()
    {
        if (canSelect)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                SelectPrevious();
                StartCoroutine(SelectDelay());
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                SelectNext();
                StartCoroutine(SelectDelay());
            }
        }
        // Lerp the content position to center the selected image
        HorizontalLayoutGroup layoutGroup = content.GetComponent<HorizontalLayoutGroup>();
        float spacing = layoutGroup.spacing;
        Vector2 contentPos = content.anchoredPosition;
        float targetPosX = selectedIndex * -images[0].rect.width + (content.rect.width - images[0].rect.width) / 2f + -spacing * selectedIndex;
        contentPos.x = Mathf.Lerp(contentPos.x, targetPosX, lerpSpeed * Time.deltaTime);
        content.anchoredPosition = contentPos;
        // Update image scales based on selection
        for (int i = 0; i < images.Length; i++)
        {
            if (i == selectedIndex)
            {
                images[i].localScale = Vector3.one * selectedScale;
            }
            else
            {
                images[i].localScale = Vector3.one * unselectedScale;
            }
        }
    }
    // Select the previous character
    private void SelectPrevious()
    {
        if (selectedIndex > 0)
        {
            selectedIndex--;
        }
        else
        {
            selectedIndex = images.Length - 1;
        }
    }
    // Select the next character
    private void SelectNext()
    {
        if (selectedIndex < images.Length - 1)
        {
            selectedIndex++;
        }
        else
        {
            selectedIndex = 0;
        }
    }
    // Wait for selectDelay seconds before allowing another selection
    private IEnumerator SelectDelay()
    {
        canSelect = false;
        yield return new WaitForSeconds(selectDelay);
        canSelect = true;
    }
}