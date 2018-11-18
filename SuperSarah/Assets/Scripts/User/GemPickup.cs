using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GemPickup : MonoBehaviour {

    GameManager gm;

    void Awake () {
        gm = FindObjectOfType<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.GetType() == typeof(BoxCollider2D))
        {
            //Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);         
            Destroy(gameObject);
            gm.PlayerAddGem();
            SwitchLevelScript(SceneManager.GetActiveScene().buildIndex);
        }
    }
    public void SwitchLevelScript(int sceneIndex)
    {
        switch (sceneIndex)
        {
            case 1:
                Level_one levelScript = FindObjectOfType<Level_one>();
                levelScript.CollectGem();
                
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
}
