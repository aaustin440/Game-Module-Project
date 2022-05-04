using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baseScript : MonoBehaviour
{
    public GameObject livingGO { get; set; }
    public Animator animator { get; private set; }
    public Rigidbody2D rbBase { get; private set; } // only want to set this once but to reference it in the derived classes
    public FSM fsm;
    public dataBaseScript baseData;
    [SerializeField] private Transform groundCheck;
    
    [SerializeField] private Transform wallCheck;
    

    public int direction { get; private set; }
    private  Vector2 velHolder;

    public virtual void Start()
    {
         direction = 1;
        livingGO = transform.Find("Living").gameObject;
        animator = livingGO.GetComponent<Animator>();
        rbBase = livingGO.GetComponent<Rigidbody2D>();
       
        fsm = new FSM();
       // fsm = new FSM(this, new FSMStateIdle(this, fsm, "idle"));
    }

    public virtual void Update()
    {
        fsm.currState.modelUpdate();
        
    }

    public virtual void FixedUpdate()
    {
        fsm.currState.physUpdate(); // put physics here as apparently is better tha Update()
    }
    public virtual bool lookWall()
        {
            return Physics2D.Raycast(wallCheck.position, livingGO.transform.right, baseData.wallDistance, baseData.whatIsGround);
        }
   
    

    public virtual bool lookGround()
    {
        return Physics2D.Raycast(groundCheck.position, Vector2.down, baseData.groundDistance, baseData.whatIsGround);
    }
    
    public virtual void enemyVel(float velocity)
    {
       velHolder.Set(direction * velocity, rbBase.velocity.y); //maybe setto 0 after ,
       rbBase.velocity = velHolder;
    }

    public virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(wallCheck.position, wallCheck.position + (Vector3)(Vector2.right * direction * baseData.wallDistance));
        Gizmos.DrawLine(groundCheck.position, groundCheck.position + (Vector3) (Vector2.down * baseData.groundDistance));
    }

    public virtual void turn() 
    {
        direction *= -1;
        livingGO.transform.Rotate(0f,180f,0f);
        // Vector3 scale = livingGO.transform.localScale;
        // scale.x *= -1;
        // livingGO.transform.localScale = scale;
    }

}
    
