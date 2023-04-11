using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp2 : MonoBehaviour
{


    public GameObject LampLight;

    //[HideInInspector]
    public GameObject DomeOff;

    //[HideInInspector]
    public GameObject DomeOn;

    public bool TurnOn;


    public Lamp myLamp;

    public void OnButtonClick()
    {
        myLamp.TurnOn = true;
    }

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {



        if (TurnOn == true)
        {
            LampLight.SetActive(true);
            DomeOff.SetActive(false);
            DomeOn.SetActive(true);

        }
        if (TurnOn == false)
        {
            LampLight.SetActive(false);
            DomeOff.SetActive(true);
            DomeOn.SetActive(false);

        }
    }
    public void TurnOnLamp()
    {
        if (TurnOn == true)
        {
            TurnOn = false;
        }
        else
        TurnOn = true;
    }

   
}
