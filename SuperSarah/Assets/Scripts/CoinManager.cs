using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinManager : MonoBehaviour {



    GameObject[] coinsSpots;
    public GameObject coinPrefab;
    string levelCoinString;

    public int totalCoins = 0;
    public int collectedCoins = 0;
    public bool coinsCollected = false;

    string nonCollectedCoins;
   
    // Use this for initialization
    void Start () {
        InstantiateCoins();
    }
    void Awake()
    {
        coinsSpots = GameObject.FindGameObjectsWithTag("coin");
        totalCoins = coinsSpots.Length;
    }


    void Update () {
		if(collectedCoins == totalCoins)
        {
            coinsCollected = true;
        }
	}
    public void CoinCollect(string coinId)
    {
        print(coinId);

        string newIdString = "";
        string prefsString = "";


        int coinIdInt = Int32.Parse(coinId); // get Id in integer
        prefsString = PlayerPrefs.GetString(getLevelCoinsString());
        print("String: " + prefsString);
        if(prefsString == "")
        {
            PlayerPrefs.SetString("coins_num_string_1", "1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80");
            prefsString = PlayerPrefs.GetString(getLevelCoinsString());
        }
        int[] coins_ids = SplitString(prefsString);// make int array from string
        foreach (int id in coins_ids)
        {
            if (coinIdInt != id && id != 0)
            {
                newIdString += id + ",";
            }
        }
        collectedCoins++;    
        PlayerPrefs.SetString(getLevelCoinsString(), newIdString);
       
    }

    public void InstantiateCoins()
    {
        int tempNonCollectedCoinsInt = 1;
        nonCollectedCoins = PlayerPrefs.GetString(getLevelCoinsString());      
        int[] coins_ids = SplitString(nonCollectedCoins);
        
        foreach (GameObject item in coinsSpots)
        {
            print(item.name);
            foreach (int id in coins_ids)
            {
                if (("coin_" + id) == item.name)
                {
                    GameObject tempCoin = Instantiate(coinPrefab, item.transform.position, Quaternion.identity);
                    tempCoin.name = id.ToString();
                    tempNonCollectedCoinsInt++;
                }
            }
        }
        collectedCoins = totalCoins - tempNonCollectedCoinsInt;
      //  print("Total Coins: " + totalCoins + "   Left Coins: " + collectedCoins);
        
    }
    int[] SplitString(string str)
    {
        string[] nonCollectedCoinsArray = str.Split(',');
        int[] coins_ids = new int[nonCollectedCoinsArray.Length]; // added Array -1
        int i = 0;
        foreach (string item in nonCollectedCoinsArray)
        {
            if(item != "")
            {
                coins_ids[i] = Int32.Parse(item);
                i++;
            }
        }
        return coins_ids;
    }
    public string getLevelCoinsString()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        return "coins_num_string_" + sceneIndex;
    }
    private string ConvertDigitToString(int i)
    {
        switch (i)
        {
            case 0: return "";
            case 1: return "one";
            case 2: return "two";
            case 3: return "three";
            case 4: return "four";
            case 5: return "five";
            case 6: return "six";
            case 7: return "seven";
            case 8: return "eight";
            case 9: return "nine";
            default:
                throw new IndexOutOfRangeException(String.Format("{0} not a digit", i));
        }
    }
    
    public int getTotalCoins()
    {
        return totalCoins;
    }
    public int getCollectedCoins()
    {
        return collectedCoins;
    }
    public int getCollectedPercentage()
    {
      
        float devidedNum = (float)collectedCoins / (float)totalCoins;
        int returnInt = (int)((float)devidedNum * 100);
     
        return returnInt;
    }

}
