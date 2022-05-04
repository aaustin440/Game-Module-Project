using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


   
    

public class collisions : MonoBehaviour
{
    [SerializeField]
    playerScript playerScript2;

    void Start()
    {
        
    }
     void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.transform.tag == "Enemy")
            {
                 //UnityEngine.Debug.Log("enemy hit");
                
                

                ;
                playerScript2.knockbackCount = playerScript2.knockbackDur;

                //playerScript2.playerJumpScript.knockbackCount = playerScript2.playerJumpScript.knockbackDur;
                //UnityEngine.Debug.Log("knockbackCount" + playerScript2.knockbackCount);
                //UnityEngine.Debug.Log("collision pos" + collision.transform.position.x);
                //UnityEngine.Debug.Log("trans pos" + transform.position.x);

                if(collision.transform.position.x < transform.position.x)
                {
                    playerScript2.knockLeft = false;
                }
                else 
                {
                    playerScript2.knockLeft = true;
                }

            
            }
            
        }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Finish")
        {
            playerScript2.completeLevel();
            UnityEngine.Debug.Log("Finsihed");
        }
            
    }
}

