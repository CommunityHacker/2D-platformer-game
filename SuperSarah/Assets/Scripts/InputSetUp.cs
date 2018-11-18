using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputSetUp : MonoBehaviour {
    public GameObject joystickInput;
    public GameObject buttonInput;

    // Use this for initialization
    void Awake()
    {
        setUpInputs();
    }

    void setUpInputs()
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

    void OnTriggerEnter2D(Collider2D col)
    {
        inputHide(true);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        inputHide(false);
    }

    void inputHide(bool inOrOut)
    {
        float alpha = inOrOut ? 0.25f : 1f;
        if (joystickInput)
        {
            Image[] images = joystickInput.GetComponentsInChildren<Image>();
            foreach (var image in images)
            {
                Color c = image.color;
                c.a = alpha;
                image.color = c;
            }
        }
        if (buttonInput)
        {
            Image[] images = buttonInput.GetComponentsInChildren<Image>();
            foreach (var image in images)
            {
                Color c = image.color;
                c.a = alpha;
                image.color = c;
            }
        }
    }
    

}
