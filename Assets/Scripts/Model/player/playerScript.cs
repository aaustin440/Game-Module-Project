using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//main player script
[System.Serializable]
public class playerScript : MonoBehaviour, ISaveData
{
    //stores a reference of the sub player scripts
    [SerializeField]
    internal playerJump playerJumpScript;

    [SerializeField]
    internal PauseMenu playerPauseMenuScript;
    [SerializeField]
    internal inputHandler inputHandlerScript;
    
    [SerializeField]
    internal collisions collisionsScript;

    [SerializeField]
    internal AudioManager audioManagerScript;

    public GameObject completeLevelUI;


    public Animator animator;
    public bool grounded = true;
    public float speed = 0f;
    public Rigidbody2D rb;
    public int jumps = 0;
    public float maxSpeed = 200.0f;
    public float v = 0f;
    public float xjumpForce = 0f;
    public float yjumpForce = 5f;
    public bool knockLeft;
    public float knockback = 10f;
    public float knockbackCount;
    public float knockbackDur = 0.2f;
    public GameObject playerGO;
    public bool completed = false;
    

    


    // allows this to be called first so subscripts that are reliant on it can reach it on start up
    public void Awake()
    {
         //base.Awake();
         // add rb and animator here 
         playerGO = GameObject.Find("player");
        rb = gameObject.GetComponent<Rigidbody2D>(); 
       
    }

    public void completeLevel()
    {
        completeLevelUI.SetActive(true);
    }

    public void restart()
    {
         completeLevelUI.SetActive(false);
    }
    
    public void LoadData(GameData data)
    {
        this.jumps = data.jumps;
        this.transform.position = data.playerPos;
    }

    public void SaveData(ref GameData data)
    {
        data.playerPos = this.transform.position;
        data.jumps = this.jumps;
    }

    public void GameWon()
    {
        Debug.Log("Game Won");
    }
}
