using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public int coins {get; set;}
    public int gems {get; set;}
    public int deaths { get; set; }

    // Use this for initialization

    public void AddCoin()
    {
        this.coins = coins + 1;
    }
    public void AddGem()
    {
        this.gems = gems + 1;
    }

}
