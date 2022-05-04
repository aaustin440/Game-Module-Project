using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class FileDataHandler 
{
   private string dataDirPath = "";

   private string dataFileName = "";

   private bool encrypt = false;

   private readonly string encryptionKey = "word";





   public FileDataHandler(string dataDirPath, string dataFileName,bool encrypt)
   {
      this.dataDirPath = dataDirPath;
      this.dataFileName = dataFileName;
      this.encrypt = encrypt;
   }


   private string EncryptDecrypt(string data)
   {
       string eData = "";
       
       for( int i=0; i<data.Length; i++)
       {
           eData += (char)(data[i] ^ encryptionKey[i % encryptionKey.Length]); //each character does an XOR operation for the original data and the index in the encrypt key
       }
       return eData;
   }

   public GameData Load()
   {
       string fullpath = Path.Combine(dataDirPath, dataFileName);
       GameData loadedData = null;
       if(File.Exists(fullpath))
       {
           try
           {    //loading the serialized data from fiel
               string dataToLoad = "";
                using (FileStream stream = new FileStream(fullpath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                }

                //decrypting the data if it is encrypted
                if(encrypt)
                {
                    dataToLoad = EncryptDecrypt(dataToLoad);
                }


                //deseralising the data from the file
                loadedData = JsonUtility.FromJson<GameData>(dataToLoad);
                
           }
           catch (Exception e)
           {
               Debug.LogError("Error loading data: " + fullpath + "\n" + e );
           }
       }
       return loadedData;

   }


   public void Save(GameData data)
   {
       string fullpath = Path.Combine(dataDirPath, dataFileName);
       try
       {
           //create the directory fopr the fill to be written into if it doesn't exist
           Directory.CreateDirectory(Path.GetDirectoryName(fullpath));

           //serialising the game object into JSon string]
           string  dataStoring = JsonUtility.ToJson(data, true);

           //encrypting the data if the encrypt flag is set
              if(encrypt)
              {
                dataStoring = EncryptDecrypt(dataStoring);
              }

           //write the newly serializeddata into the file
           using(FileStream stream = new FileStream(fullpath, FileMode.Create))
           {
               using(StreamWriter writer = new StreamWriter(stream))
               {
                   writer.Write(dataStoring);
               }
           }


       }
       catch (Exception e)
       {
           Debug.Log("Could not save data to file" + fullpath +"\n" + e);
           throw;
       }
   }

   
}
