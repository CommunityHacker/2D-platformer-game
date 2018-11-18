using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject settingsPanel;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    } 
 
    public void OpenSettings()
    {
        if (settingsPanel.active) { return; }
        settingsPanel.SetActive(true);
    }
   
    public void CloseSettingsPanel()
    {
        settingsPanel.SetActive(false);
    }

      
}
