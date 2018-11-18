using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOne : MonoBehaviour {
    [SerializeField] float speed = 1f;
    Rigidbody2D enemyOneRigidbody;
	
	void Start ()
    {

        enemyOneRigidbody = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {

        if (IsFacingRight())
        {
            enemyOneRigidbody.velocity = new Vector2(speed, 0f);
        }
        else
        {
            enemyOneRigidbody.velocity = new Vector2(-speed, 0f);
        }
        
    }
    bool IsFacingRight()
    {
        return transform.localScale.x > 0;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(enemyOneRigidbody.velocity.x)), 1f);
    }
}
