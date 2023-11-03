using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.IO;

namespace AR_Fukuoka
{
    public class ScriptChange : MonoBehaviour
    {
        public TMP_InputField inputField;
        public TextMeshProUGUI sceneText;
        public TextMeshProUGUI logText;
        public ScriptData[] scriptData;
        public Button submitButton;

        private int currentIndex = 0;
        private string logFilePath;

        private void Start()
        {
            UpdateSceneText();
            InitializeLogFile();
            submitButton.onClick.AddListener(CheckInputText);

            // Load and display the contents of the log file
            if (File.Exists(logFilePath))
            {
                string logContent = File.ReadAllText(logFilePath);
                logText.text = logContent;
            }
        }

        public void CheckInputText()
        {
            string inputText = inputField.text.ToLower();
            string requiredText = scriptData[currentIndex].requiredText.ToLower();

            if (inputText == requiredText)
            {
                Debug.Log("inputText and RequiredText are the same");

                // Check if the previous script is active
                if (currentIndex > 0 && !scriptData[currentIndex - 1].script.enabled)
                {
                    Debug.Log("Solve the current mystery first!");
                    return;
                }

                // Disable the previous script
                if (currentIndex > 0)
                {
                    scriptData[currentIndex - 1].script.enabled = false;
                }

                // Enable the current script
                scriptData[currentIndex].script.enabled = true;
                currentIndex++;

                if (currentIndex >= scriptData.Length)
                {
                    inputField.interactable = false;
                    sceneText.text = "All scripts enabled!";
                }
                else
                {
                    UpdateSceneText();
                }

                LogText(inputText);
                inputField.text = "";
            }
        }

        private void UpdateSceneText()
        {
            sceneText.text = "Clue: " + scriptData[currentIndex].clue;
        }

        private void InitializeLogFile()
        {
            string fileName = "text_log.txt";
            logFilePath = Path.Combine(Application.persistentDataPath, fileName);
            Debug.Log(logFilePath);
            File.WriteAllText(logFilePath, "");
        }

        private void LogText(string text)
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string logEntry = "[" + timestamp + "] " + text + "\n";
            File.AppendAllText(logFilePath, logEntry);

            // Update the log text in the UI
            logText.text = logEntry + logText.text;
        }
    }

    [System.Serializable]
    public class ScriptData
    {
        public string requiredText;
        public string clue;
        public MonoBehaviour script;
        public string scriptName;
    }
}
