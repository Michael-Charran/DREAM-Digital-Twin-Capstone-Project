using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSelector : MonoBehaviour
{
    public Dropdown sceneDropdown;
    public Button loadButton;

    public void Start()
    {
        sceneDropdown = GetComponentInChildren<Dropdown>();
        loadButton = GetComponentInChildren<Button>();

        Debug.Log("Dropdown found: " + (sceneDropdown != null));
        Debug.Log("Button found: " + (loadButton != null));
    }
    public void LoadScene()
    {
        int sceneIndex = sceneDropdown.value;
        string sceneName = sceneDropdown.options[sceneIndex].text;
        SceneManager.LoadScene(sceneName);
    }
   
}