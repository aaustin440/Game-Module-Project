using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newBaseData", menuName = "Data/Base_Data/BaseData")] //allows abvle to store data in the unity editor

public class dataBaseScript : ScriptableObject // scriptable object is a data contained to save large amounts of data independent of class instances

{
    public LayerMask whatIsGround;
    public float wallDistance = 0.25f;
    public float groundDistance = 0.4f;

}
