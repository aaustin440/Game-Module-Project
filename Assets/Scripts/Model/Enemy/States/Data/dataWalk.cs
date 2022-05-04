using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newWalkData", menuName = "Data/State_Data/ Walk_State_Data")] // allows abvle to store data in the unity editor

public class dataWalk : ScriptableObject // scriptable object is a data contained to save large amounts of data independent of class instances
{
    public Animator animator;
    public float speed =2f;
    

}

