using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItem : MonoBehaviour {

	public string text { get; set; }
    public int percentage { get; set; }
    

    public bool Completed()
    {
        return this.percentage >= 100 ? true : false;
       
    }
}
