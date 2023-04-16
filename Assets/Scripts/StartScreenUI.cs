using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScreenUI : MonoBehaviour
{
    public Dropdown levelDropdown;
    public Button startButton;

    private void Start()
    {
        // Populate the dropdown with the available scenes
        List<string> sceneNames = new List<string>();
        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            string scenePath = SceneUtility.GetScenePathByBuildIndex(i);
            string sceneName = System.IO.Path.GetFileNameWithoutExtension(scenePath);
            sceneNames.Add(sceneName);
        }
        levelDropdown.AddOptions(sceneNames);

        // Add a listener to the start button
        startButton.onClick.AddListener(StartGame);
    }

    private void StartGame()
    {
        // Load the selected scene from the dropdown
        int sceneIndex = levelDropdown.value;
        SceneManager.LoadScene(sceneIndex);
    }
}
