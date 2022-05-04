//using System.Numerics;
using System.Threading;
//using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class playerJump : MonoBehaviour
{
    [SerializeField]
    playerScript playerScript2;
    
    private float playerInput;
    public float yJumpForce;
    public float xJumpForce = 0.0f;
    public AudioManager audioManager;
    public GameObject AudioManager2;

    [Header("Events")]
	[Space]

	public UnityEvent OnLandEvent;

	[System.Serializable]
	public class BoolEvent : UnityEvent<bool> { }

    
   
    
    //private Rigidbody2D rb;
    public bool grounded;
    //public bool knockLeft;
    public bool canJump = true;
    public LayerMask ground;
    public PhysicsMaterial2D bounceMat, normalMat;
    public AudioClip jumpSound;
    public AudioSource jumpSource;
    public AudioClip landSound;
    public AudioClip theme;
    public AudioSource themeSource;
    public bool walking;
    public bool jumping;
    bool facingRight = true;


    // Start is called before the first frame update
    void Awake()
    {
        playerScript2.rb = gameObject.GetComponent<Rigidbody2D>();
        print("player jump staring");
        yJumpForce = 5f;
        //AudioManager.Instance.Play("jump_SFX");
        //var am = new AudioManager();
        //am.Play("jump_SFX");
        
    }
   
    
    void Update()
    {
        // playerScript2.v = playerScript2.rb.velocity.magnitude;
        // //if players velocity exceeds max velocity then cap it
        // if (playerScript2.rb.velocity.y >playerScript2.maxSpeed)
        // {
        //    terminalVel();
        // }
        

         playerInput = Input.GetAxisRaw("Horizontal");

        //Debug.Log("knockbackcoutn :" + playerScript2.knockbackCount);  
        if ( playerScript2.knockbackCount <= 0f) // if player isnt currently being knocked back
        {
            if(grounded  && !playerScript2.inputHandlerScript.spacePressed ) //allows walking only if grounded and not jumping
            {
                playerScript2.rb.velocity = new Vector2(playerInput * playerScript2.speed, playerScript2.rb.velocity.y);
                //playerScript2.rb.AddForce(new Vector2(playerInput * playerScript2.speed, 0) * Time.deltaTime * 5f);
                 //* Time.deltaTime * 80; //*Time.deltaTime* 11);
                playerScript2.animator.SetFloat("Speed", Mathf.Abs(playerScript2.rb.velocity.x));
            }
        }
        else
        {
            if(playerScript2.knockLeft)
            {
                playerScript2.rb.velocity = new Vector2(-playerScript2.knockback, playerScript2.knockback); //knocks player left
            }
            if(!playerScript2.knockLeft)
            {
                playerScript2.rb.velocity = new Vector2(playerScript2.knockback, playerScript2.knockback);  // knocks player right
            }
            playerScript2.knockbackCount -= Time.deltaTime;
        }
        
       
         grounded = Physics2D.OverlapBox(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y -0f), new Vector2(1.3f, 0.1f), 0f, ground); //checks if player is grounded

        //increases x and y jump force based off of time held for jump key and movement keys
        if (Input.GetKey(KeyCode.Space) && grounded && canJump)
        {
             yJumpForce+= 0.1f * Time.deltaTime * 100;

             if(Input.GetKey(KeyCode.A))
             {
                 xJumpForce -= 0.1f * Time.deltaTime * 100;
             }
                if(Input.GetKey(KeyCode.D))
                {
                    xJumpForce += 0.1f * Time.deltaTime * 100;
                }
            
        }

        if(grounded)
        {
            playerScript2.animator.SetBool("Jumping", false);
        }
         if(Input.GetKeyUp("space")) //jumps if space released before max yJumpForce reached
        {
            if(grounded && canJump)
            { 
                
                playerScript2.rb.velocity = new Vector2(xJumpForce, yJumpForce); //* Time.deltaTime * 100;
                FindObjectOfType<AudioManager>().Play("jump_SFX");
                playerScript2.jumps = playerScript2.jumps + 1;
                yJumpForce = 5f;
                xJumpForce = 0f;
                playerScript2.animator.SetBool("Jumping", true);

                
            }
            canJump = true;
        }

        if ( yJumpForce >= 18f && grounded) // jumps if max yJumpforce reached
        {
            {
            //float tempx = playerInput * speed;
            float tempx = xJumpForce;
            float tempy = yJumpForce;
            playerScript2.rb.velocity = new Vector2(tempx,tempy);
            FindObjectOfType<AudioManager>().Play("jump_SFX");
            playerScript2.jumps = playerScript2.jumps + 1;
            //playerScript2.rb.velocity = new Vector2(tempx, tempy); //* Time.deltaTime * 300;
             //playerScript2.rb.AddForce(Vector2.up * tempx, ForceMode2D.Impulse);
            //  playerScript2.rb.AddForce(playerScript2.rb.velocity * playerScript2.speed);
             playerScript2.animator.SetBool("Jumping", true);
            
            
            Invoke("jumpReset", 0.1f); // stops double jumps by calling jumpReset function 0.1 after jump}
            }
            canJump = true;
         }


        
        if((playerScript2.inputHandlerScript.leftPressed == true && playerScript2.inputHandlerScript.rightPressed == true) && grounded)
        {
            stopPlayer();
        }

        if(playerInput < 0 && facingRight)
        {
            flip();
        }
        else if(playerInput > 0 && !facingRight)
        {
            flip();
        }
        

    }
    void flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    public void walk()
    {
        playerScript2.rb.velocity = new Vector2(playerInput * playerScript2.speed, playerScript2.rb.velocity.y);
        FindObjectOfType<AudioManager>().Play("walkSFX");
    }


    public void stopPlayer()
    {
        playerScript2.rb.velocity = new Vector2(0.0f, 0.0f);
    }

    

    //prevents bounbcing effect after jumping - would keep jumping
    private void jumpReset()
    {
        yJumpForce = 5f;
        xJumpForce = 0.0f;
        canJump = false;

    }

    public void OnLanding()
    {
        FindObjectOfType<AudioManager>().Play("land_SFX");
        playerScript2.animator.SetBool("Jumping", false);
    }

    // public void terminalVel()
    // {
    //     playerScript2.rb.velocity.y = 22f; //sets max vel  
    // }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0f), new Vector2(1.3f, 0.1f));
    }
}
