using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour {


    [SerializeField]
    float runSpeed = 50f;
    [SerializeField]
    float jumpSpeed = 28f;
    [SerializeField]
    float climbingSpeed = 50f;
   
    public Vector2 deathVelocity = new Vector2(25f,25f);
    float startGravityScale;
    bool isAlive = true;

    public Joystick joystick;
    public GameObject deathPanel;

    Rigidbody2D playerRigidbody;
    Animator playerAnimator;
    CapsuleCollider2D playerCollider;
    BoxCollider2D playerFeets;

    

    void Start () {
       
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        playerCollider = GetComponent<CapsuleCollider2D>();
        playerFeets = GetComponent<BoxCollider2D>();

        startGravityScale = playerRigidbody.gravityScale;
    }
	
	void Update () {
              
        if (!isAlive) { return; }
        Run();
        Jump();
        ClimbLadder();
        FlipPlayerSprite();
        Die();
    }

    private void Run()
    {  
        float movementFloat = CrossPlatformInputManager.GetAxis("Horizontal");
        Vector2 playerVelocity = new Vector2(movementFloat * runSpeed, playerRigidbody.velocity.y);
        playerRigidbody.velocity = playerVelocity;

        bool isMoving = Mathf.Abs(playerRigidbody.velocity.x) > Mathf.Epsilon;
        playerAnimator.SetBool("Running", isMoving);
    }
    public void ClimbLadder()
    {
       
        if (!playerFeets.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            joystick.ClambRange = 0;
            playerRigidbody.gravityScale = startGravityScale;
            playerAnimator.SetBool("Climbing", false);
            return;
        }

        joystick.ClambRange = 200;
        float movementFloat = CrossPlatformInputManager.GetAxis("Vertical");
        Vector2 climbVelocity = new Vector2(playerRigidbody.velocity.x, movementFloat * climbingSpeed);


        playerRigidbody.velocity = climbVelocity;
        playerRigidbody.gravityScale = 0f;

        bool isClimbing = Mathf.Abs(playerRigidbody.velocity.y) > Mathf.Epsilon;
        playerAnimator.SetBool("Running", false);
        playerAnimator.SetBool("Climbing", isClimbing);

    }
    /*
    public void ClimbLadderButton()
    {
        print("CLIMB 1");
        if (!playerFeets.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            //  joystick.axesToUse = Joystick.AxisOption.OnlyHorizontal;
          
            playerRigidbody.gravityScale = startGravityScale;
            playerAnimator.SetBool("Climbing", false);
            return;
        }


        print("CLIMB 2");



        //  transform.rotation = Quaternion.LookRotation(Vector3.forward, moveVector);
        // transform.Translate(moveVector * 2 * Time.deltaTime, Space.World);
        //     bool isMoving = Mathf.Abs(playerRigidbody.velocity.x) > Mathf.Epsilon;
        //    playerAnimator.SetBool("Running", isMoving);

        /////////////////////////////////////////////////
        //joystick.ClambRange = 200;
        float movementFloat = CrossPlatformInputManager.GetAxis("Vertical");
        Vector2 climbVelocity = new Vector2(playerRigidbody.velocity.x, movementFloat * climbingSpeed);


        playerRigidbody.velocity = climbVelocity;
        playerRigidbody.gravityScale = 0f;

        bool isClimbing = Mathf.Abs(playerRigidbody.velocity.y) > Mathf.Epsilon;
        playerAnimator.SetBool("Running", false);
        playerAnimator.SetBool("Climbing", isClimbing);

    }
    */
    private void Jump()
    {
        
        if (!playerFeets.IsTouchingLayers(LayerMask.GetMask("Ground"))){  return; }
        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            print("Jump");
            Vector2 jumpVelocityPower = new Vector2(0f, jumpSpeed);
            playerRigidbody.velocity += jumpVelocityPower;
        }
    }

    private void Die()
    {
        //TOODOO: make it better with more ways to die depend on enemy tag...

        if (playerCollider.IsTouchingLayers(LayerMask.GetMask("Enemy")))
        {            
            isAlive = false;
            playerAnimator.SetTrigger("Die");
            playerRigidbody.velocity = deathVelocity;
            //TOODOO: its freeze before kick
            if (playerFeets.IsTouchingLayers(LayerMask.GetMask("Ground")))
            {
                playerRigidbody.constraints = RigidbodyConstraints2D.FreezePositionX;
            }
            PlayerPrefs.SetInt("Player_deaths", PlayerPrefs.GetInt("Player_deaths") + 1);
            deathPanel.SetActive(true);
            
        }     
    }

    private void FlipPlayerSprite()
    {
        bool isMovingForward = Mathf.Abs(playerRigidbody.velocity.x) > Mathf.Epsilon;
        if (isMovingForward)
        {
            transform.localScale = new Vector2(Mathf.Sign(playerRigidbody.velocity.x), 1f);
        }
    }
   
  
}
