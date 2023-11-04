using UnityEngine;
using UnityEngine.UI;

public class ToggleObjectVisibility : MonoBehaviour
{
    public GameObject objectToToggle; // Reference to the GameObject you want to show/hide

    private bool isObjectVisible = false; // Keeps track of the object's visibility

    public void ToggleVisibility()
    {
        isObjectVisible = !isObjectVisible; // Toggle the visibility state

        objectToToggle.SetActive(isObjectVisible); // Set the GameObject's active state based on the visibility state
    }
}
