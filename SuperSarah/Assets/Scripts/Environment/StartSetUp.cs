using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSetUp : MonoBehaviour {

    public GameObject joystickInput;
    public GameObject buttonInput;

    void Awake()
    {
        SetUpInputs();
    }

    void SetUpInputs()
    {
        if (PlayerPrefs.GetString("iput_option") == "Joystick")
        {
            buttonInput.SetActive(false);
            joystickInput.SetActive(true);
        }
        else if (PlayerPrefs.GetString("iput_option") == "Buttons")
        {
            joystickInput.SetActive(false);
            buttonInput.SetActive(true);
        }
    }
}
