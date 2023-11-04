using UnityEngine;
using UnityEngine.UI;

public class ToggleButtonSprites : MonoBehaviour
{
    public Sprite circleSprite;   // Assign "cross" sprite in the Inspector
    public Sprite crossSprite;  // Assign "circle" sprite in the Inspector

    private bool isCircle = true;
    private Image buttonImage;  // Reference to the button's Image component

    private void Start()
    {
        buttonImage = GetComponent<Image>();
    }

    public void OnButtonClick()
    {
        // Toggle between "cross" and "circle" when the button is clicked
        isCircle = !isCircle;
        buttonImage.sprite = isCircle ? circleSprite : crossSprite;
    }
}
