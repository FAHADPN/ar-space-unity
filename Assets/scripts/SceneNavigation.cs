using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigation : MonoBehaviour
{
    public string sceneToLoad; // Name of the scene to load

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
