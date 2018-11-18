using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour {

     [SerializeField] AudioClip coinPickUpSFX;

    CoinManager cm;
    GameManager gm;

    void Awake()
    {
        cm = FindObjectOfType<CoinManager>();
        gm = FindObjectOfType<GameManager>();
    }
	public void OnTriggerEnter2D(Collider2D other)
    {       
       // print("Type : " + other.GetType());
        if(other.GetType() == typeof(CapsuleCollider2D))
        {
            AudioSource.PlayClipAtPoint(coinPickUpSFX, Camera.main.transform.position);
            cm.CoinCollect(this.gameObject.name);
            gm.PlayerAddCoin();
            Destroy(gameObject);
        }

    }
    
}
