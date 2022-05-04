using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISaveData 
{
   void LoadData(GameData data);//only has to read the data

   void SaveData(ref GameData data); //passing by ref to allow implementing script to modify the data
}