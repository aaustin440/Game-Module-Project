using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData 
{
    public int jumps;
    public Vector3 playerPos;

    public GameData()
    {
        this.jumps = 0;
        playerPos = new Vector3(0,-9,0);
    }
}
