using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityEngine.Networking;

public class LampController : MonoBehaviour
{
    // Replace YOUR_IFTTT_KEY with your actual IFTTT key
    private string IFTTT_KEY = "g_M_PT8XjF6rz-21JaPR0R4EgowCyP-ocE5feuD_ceM";
    // Replace YOUR_EVENT_NAME with the name of the event you created in your IFTTT applet
    private string EVENT_NAME = "hey";
    private string IFTTT_URL;

    public GameObject LampLight;
    public GameObject DomeOff;
    public GameObject DomeOn;

    private void Start()
    {
        IFTTT_URL = "https://maker.ifttt.com/trigger/" + EVENT_NAME + "/with/key/" + IFTTT_KEY;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TriggerIFTTTEvent();
        }
    }

    public void TriggerIFTTTEvent()
    {
        StartCoroutine(SendIFTTTRequest());
    }

    IEnumerator SendIFTTTRequest()
    {
        using (UnityWebRequest request = UnityWebRequest.Get(IFTTT_URL))
        {
            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(request.error);
            }
            else
            {
                Debug.Log("IFTTT event triggered successfully!");
            }
        }
    }

    public void TurnOnVirtualLamp(bool isOn)
    {
        LampLight.SetActive(isOn);
        DomeOff.SetActive(!isOn);
        DomeOn.SetActive(isOn);
    }

    // This method will be called by IFTTT when your Wemo switch turns on/off
    public void OnWemoSwitchEvent(string eventData)
    {
        if (eventData == "on")
        {
            TurnOnVirtualLamp(true);
        }
        else if (eventData == "off")
        {
            TurnOnVirtualLamp(false);
        }
    }
}
