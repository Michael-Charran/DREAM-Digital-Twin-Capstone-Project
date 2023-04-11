using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public Lamp lamp;

    void Start()
    {
        // Get the button component
        Button button = GetComponent<Button>();

        // Add a listener to call the ToggleLamp function when the button is clicked
        button.onClick.AddListener(ToggleLamp);
    }

    void ToggleLamp()
    {
        // Toggle the lamp's state
        lamp.TurnOn = !lamp.TurnOn;
    }
}
