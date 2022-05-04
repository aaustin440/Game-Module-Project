using System.Security;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputHandler : MonoBehaviour
{
    [SerializeField]
    playerScript playerScript2;

    public bool leftPressed;
    public bool rightPressed;
    public bool spacePressed;
    public GameObject t;

   
    // Start is called before the first frame update
   
    // Update is called once per frame
    void Update()
    {
        //is A and D pressed player stop
        if (Input.GetKeyDown(KeyCode.A)||Input.GetKeyDown(KeyCode.LeftArrow))
            {
                leftPressed = true;
                
            }
            
        if (Input.GetKeyDown(KeyCode.D) ||Input.GetKeyDown(KeyCode.RightArrow))
            rightPressed = true;

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
            leftPressed = false;

        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
            rightPressed = false;
        
        if (Input.GetKeyDown(KeyCode.Space))
            spacePressed = true;
        
        if (Input.GetKeyUp(KeyCode.Space))
            spacePressed = false;

        
        

        if (leftPressed == true && rightPressed == true && playerScript2.grounded == true)
           // playerScript2.speed = 0;

        if ((leftPressed == true || rightPressed == true) && (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow)) || (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow)))
        {
           // playerScript2.speed = 0;
            leftPressed = false;
            rightPressed = false;
        }
        
        // if neither pressed allow movement  
        if (leftPressed == false || rightPressed == false  && playerScript2.grounded == true)
        {
            //playerScript2.speed = 0;
             playerScript2.speed = 6;
        }
        
    }
}
