using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsUI : MonoBehaviour {

    public Text coinsText;
    public Text gemsText;
    public Text deathsText;

    GameManager gm;

    void Awake()
    {
        gm = FindObjectOfType<GameManager>();
    }

    void Start () {

        RefreshTexts(gm.GetCoins(), gm.GetGems(),gm.GetDeaths());

    }

    public void RefreshTexts(int tempText_one,int tempText_two, int deaths)
    {
       // print("seted 1: " + coinsText.name + " Two : " + tempText_two);

        coinsText.text = tempText_one.ToString();        
        gemsText.text = tempText_two.ToString();
        deathsText.text = deaths.ToString();

    }
}
