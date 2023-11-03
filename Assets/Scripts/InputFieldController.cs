using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputFieldController : MonoBehaviour
{
    public TMP_InputField inputField;
    public Button submitButton;

    public void ToggleInputField()
    {
        inputField.gameObject.SetActive(!inputField.gameObject.activeSelf);
        submitButton.gameObject.SetActive(!submitButton.gameObject.activeSelf);
    }
}
