using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour {

    public Button inputButton;

    public GameObject joystickInput;
    public GameObject buttonInput;

    
	// Use this for initialization
	void Start () {

        inputButton.GetComponentInChildren<Text>().text = PlayerPrefs.GetString("iput_option");
        SetInputIngame();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void InputOption()
    {
        if(inputButton.GetComponentInChildren<Text>().text == "Joystick")
        {
            PlayerPrefs.SetString("iput_option", "Buttons");
            inputButton.GetComponentInChildren<Text>().text = "Buttons";
            SetInputIngame();
        }
        else
        {
            PlayerPrefs.SetString("iput_option", "Joystick");
            inputButton.GetComponentInChildren<Text>().text = "Joystick";
            SetInputIngame();   
        }
    }

    public void SetInputIngame()
    {
        if(PlayerPrefs.GetString("iput_option") == "Joystick")
        {
            buttonInput.SetActive(false);
            joystickInput.SetActive(true);
        }
        else if(PlayerPrefs.GetString("iput_option") == "Buttons")
        {
            joystickInput.SetActive(false);
            buttonInput.SetActive(true);
        }
    }
    

}
