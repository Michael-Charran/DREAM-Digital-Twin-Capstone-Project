using UnityEngine;

public class OtherScript : MonoBehaviour
{
    public NewBehaviourScript newBehaviourScript;

    private void Start()
    {
        // Find the GameObject with the NewBehaviourScript component attached
        GameObject gameObjectWithScript = GameObject.FindWithTag("NewBehaviourScriptObject");

        // Get the NewBehaviourScript component from the GameObject
        newBehaviourScript = gameObjectWithScript.GetComponent<NewBehaviourScript>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Call the TriggerIFTTTEvent method on the NewBehaviourScript component
            newBehaviourScript.TriggerIFTTTEvent();
        }
    }
}
