using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newIdleData", menuName = "Data/State_Data/ Idle_State_Data")] // //allows abvle to store data in the unity editor

public class dataIdle : ScriptableObject 
{
    public float minIdltime =0.8f;
    public float maxIdltime = 1.5f;
}
