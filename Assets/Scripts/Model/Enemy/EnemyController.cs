// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class EnemyController : MonoBehaviour
// {
//     public float wallCheckDistance, groundCheckDistance;
//     private int facingDir;
//     private States curState;
//     private bool groundDetected, wallDetected;
//     private GameObject living;
//     private Rigidbody2D aiRB;
//     private Animator aiAnimator;
//     public float speed;
//     private Vector2 movement;

//     [SerializeField] private LayerMask whatIsGround;
//     [SerializeField] private Transform groundCheck, wallCheck;


//     private enum States
//     {
//         walking,
//         turning,
//         attacking
//     }

//     // Start is called before the first frame update
//     void Start()
//     {
//         living = transform.Find("Living").gameObject;
//         aiRB = living.GetComponent<Rigidbody2D>();
//         aiAnimator = living.GetComponent<Animator>();
//         facingDir =1;

//     }

    

//     private void Update()
//     {
//         switch (curState)
//         {
//             case States.walking:
//                 UpdateWalkingState();
//                 break;
//             case States.turning:
//                 UpdateTurningState();
//                 break;
//             case States.attacking:
//                 UpdateAttackingState();
//                 break;
//         }
//     }

//     private void changeState(States newState)
//     {

//         //exits current state so new state can be entered
//         switch (curState)
//         {
//             case States.walking:
//                 stopWalkingState();
//                 break;
//             case States.turning:
//                 stopturningState();
//                 break;
//             case States.attacking:
//                 stopAttackingState();
//                 break;
//         }
//         //enters new state
//         switch (newState)
//         {
//             case States.walking:
//                 startWalkingState();
//                 break;
//             case States.turning:
//                 startturningState();
//                 break;
//             case States.attacking:
//                 startAttackingState();
//                 break;
//         }
//         curState = newState;
        

//     }
//     private void turn()
//     {
//         facingDir *=-1;
//         living.transform.Rotate(0.0f, 180.0f , 0.0f); //rotate 180 degrees aka flip on x axis

//     }

//     //walking state

//     private void startWalkingState()
//     {

//     }

//     private void stopWalkingState()
//     {

//     }

//     private void UpdateWalkingState()
//     {
//         wallDetected = Physics2D.Raycast(wallCheck.position, transform.right, wallCheckDistance, whatIsGround);
//         groundDetected = Physics2D.Raycast(groundCheck.position, Vector2.down , groundCheckDistance, whatIsGround);

//         if(!groundDetected || wallDetected)
//         {
//             turn();
//         }else
//         {
//            movement.Set(speed * facingDir, aiRB.velocity.y); 
//            aiRB.velocity = movement;

//         }
//     }

//     private void OnDrawGizmos()
//     {
//         Gizmos.DrawLine(wallCheck.position, new Vector2 (wallCheck.position.x + wallCheckDistance,wallCheck.position.y));
//         Gizmos.DrawLine(groundCheck.position, new Vector2(groundCheck.position.x, groundCheck.position.y -groundCheckDistance));
//     }

// }
