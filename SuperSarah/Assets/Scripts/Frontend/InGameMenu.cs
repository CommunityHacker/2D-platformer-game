using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameMenu : MonoBehaviour {

    public GameObject inGameMenuPanel;
    public GameObject questPanel;
    public Text coinsStatsTotal;
    public Text coinsStatsCollected;

    public Text gemsStatsTotal;
    public Text gemsStatsCollected;

    CoinManager cm;

    void Awake()
    {
        cm = GetComponent<CoinManager>();      
    }

    public void SetMenuTexts()
    {
        coinsStatsTotal.text = cm.getTotalCoins().ToString();
        coinsStatsCollected.text = cm.getCollectedCoins().ToString();
    }

    public void OpenIngameMenu()
    {
        if (!inGameMenuPanel.active && !questPanel.active)
        {
            SetMenuTexts();
            inGameMenuPanel.SetActive(true);
        }else
        {
            inGameMenuPanel.SetActive(false);
        }      
    }
}
