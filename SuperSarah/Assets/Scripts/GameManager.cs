using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static Player player;

    StatsUI statsUi;
    
    void Awake()
    {
        DontDestroyOnLoad();
        setIntput();
        SetPlayer();

    }

    public void SetPlayer()
    {
        player = new Player();
        player.coins = PlayerPrefs.GetInt("Player_coins");
        player.deaths = PlayerPrefs.GetInt("Player_deaths");
        player.gems = PlayerPrefs.GetInt("Player_gems");
        if(player.deaths == 0)
        {
            player.deaths = 0;
        }
    }
    public void DontDestroyOnLoad()
    {
        int numGameManagers = FindObjectsOfType<GameManager>().Length;
        if (numGameManagers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Combine AddCoin and AddGem functions if needed
    public void PlayerAddCoin()
    {
        statsUi = FindObjectOfType<StatsUI>(); //call it once again cause game object is from previus scenne
        player.AddCoin();
   
        PlayerPrefs.SetInt("Player_coins", player.coins);
        statsUi.RefreshTexts(player.coins,player.gems,player.deaths);


    }
    public void PlayerAddGem()
    {
        statsUi = FindObjectOfType<StatsUI>(); //call it once again cause game object is from previus scenne
        player.AddGem();
        
        PlayerPrefs.SetInt("Player_gems", player.gems);
        statsUi.RefreshTexts(player.coins, player.gems, player.deaths);


    }
    public int GetCoins()
    {
        return player.coins;
    }
    public int GetGems()
    {
        return player.gems;
    }
    public int GetDeaths()
    {
        return player.deaths;
    }

}
