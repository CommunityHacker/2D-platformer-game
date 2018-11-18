using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level_one : MonoBehaviour {

    CoinManager cm;

    public GameObject gemObject;
    bool gemCollected = false;

    QuestItem[] quests = new QuestItem[2];

    void Awake()
    {    
        gemCollected = PlayerPrefs.GetInt("levelee_one_gem") > 0 ? true : false;       
        gemObject.SetActive(!gemCollected);
        cm = FindObjectOfType<CoinManager>();
    }
    void Start () {
        print(cm.getCollectedPercentage() + " here");
        GetQuests();
    }

    public QuestItem[] GetQuests()
    {
        quests[0] = SetCollectAllCoinsQuest();
        quests[1] = SetCollectGemQuest();
        return quests;
    }
    public QuestItem SetCollectAllCoinsQuest()
    {
        QuestItem quest_one = new QuestItem();
        quest_one.text = "Collect All Coins";
        quest_one.percentage = cm.getCollectedPercentage();
        return quest_one;
    }

    public QuestItem SetCollectGemQuest()
    {
        QuestItem quest_two = new QuestItem();
        quest_two.text = "Find the Gem";
        quest_two.percentage = gemCollected ? 100 : 0;

        return quest_two;
    }
    public void CollectGem()
    {
        gemCollected = true;
        PlayerPrefs.SetInt("level_one_gem", 1);
    }


}
