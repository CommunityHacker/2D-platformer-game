using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour {


    public static void setCoinString(string coinsString)
    {
        PlayerPrefs.SetString("non_collected_coins_string", coinsString);
    }

  public static void setInputOptions(string inputOptionName)
    {
        PlayerPrefs.SetString("iput_option", inputOptionName);
    }

}
