using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuestsUI : MonoBehaviour {

    public GameObject menuPanel;
    public GameObject questPanel;
    public GameObject scrollContent;
    QuestItem[] quests;
    List<GameObject> questsList = new List<GameObject>();
    InGameMenu igm;

    public GameObject questItemPrefab;
    // Use this for initialization
    void Awake()
    {
        igm = GetComponent<InGameMenu>();
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	
    public void SetQuestUI()
    {
        //Call every time when panel is open
        //
        //TOODOO:: Fix that multy foreach 
   

        menuPanel.SetActive(false);
        SwitchLevelScript(SceneManager.GetActiveScene().buildIndex);

        if (scrollContent.transform.childCount > 0)
        {
            print("Vise od 0");
            int tempNum = 0;
            foreach (GameObject item in questsList)
            {
                print("Firsr foreach");
                Text[] tempTexts = item.GetComponentsInChildren<Text>();
                print("Texts count : " + tempTexts.Length);

                foreach (Text textItem in tempTexts)
                {
                    print("Secound foreach");
                    if (textItem.name == "QuestText")
                    {
                        textItem.text = quests[tempNum].text;
                    }
                    else if (textItem.name == "QuestCompleteText")
                    {
                        textItem.text = quests[tempNum].percentage + " %";
                    }
                }
                tempNum++;
            }

        }else
        {
            // Make new one if was empty
            foreach (QuestItem qItem in quests)
            {
                print(qItem.Completed());
              //  if (qItem.completed())
             //   {
                //    print("DA");
                    questItemPrefab.GetComponentInChildren<Image>().color = Color.green;
                    questItemPrefab.GetComponentInChildren<Image>().color = qItem.Completed() ? Color.green: Color.grey;
             //   }
                Text[] questTexts = questItemPrefab.GetComponentsInChildren<Text>();
                foreach (Text item in questTexts)
                {
                    if (item.name == "QuestText")
                    {
                        item.text = qItem.text;
                    }
                    else if (item.name == "QuestCompleteText")
                    {
                        item.text = qItem.percentage + " %";
                    }
                }
               
                GameObject questItem = Instantiate(questItemPrefab);
              
                questsList.Add(questItem);
                questItem.transform.SetParent(scrollContent.transform, false);
            }
        } 

        questPanel.SetActive(true);

    }
    public void SwitchLevelScript(int sceneIndex)
    {  
        switch (sceneIndex)
        {
            case 1:
                Level_one levelScript = GetComponent<Level_one>();
                quests = levelScript.GetQuests();
                break;
            case 2:
               // Console.WriteLine("Case 2");
                break;
            case 4:
              //  Console.WriteLine("Case 2");
                break;
            case 5:
              //  Console.WriteLine("Case 2");
                break;
            case 6:
              //  Console.WriteLine("Case 2");
                break;
            default:
                print("Default case");
                break;
        }
        
    }
    public void ClosePanel()
    {
        questPanel.SetActive(false);
    }

}
