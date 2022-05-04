using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SaveDataManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string fileName;
    private FileDataHandler fileDataHandler;
    [SerializeField] private bool encrypt;
    private GameData gameData;
    public static SaveDataManager instance { get; private set; } //privately set for security reasons
    private List<ISaveData> saveDataObjects;
    private bool temp;
    [SerializeField] playerScript playerScript2;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one SaveDataManager in scene");
        }
        instance = this;
    }

    private void Start()
    {
        this.fileDataHandler = new FileDataHandler(Application.persistentDataPath, fileName, encrypt);
        this.saveDataObjects = FindAllDataPersistence();
        LoadGame();
        
    }
    
    public void SaveGame()
    {
        //sends data to other scrips so they can use it
        foreach (ISaveData saveDataObject in saveDataObjects)
        {
            saveDataObject.SaveData(ref gameData);
        }
        //Debug.Log("saved jumps =" + gameData.jumps);

        fileDataHandler.Save(gameData);
    }

    //on exiting game save the game
    private void OnApplicationQuit()
    {
        SaveGame();
        foreach (ISaveData saveDataObj in saveDataObjects)
        {
            saveDataObj.SaveData(ref gameData);
        }
        Debug.Log("Game Saved jumps" + gameData.jumps);
    }


    public void LoadGame()
    {
        
        this.gameData = fileDataHandler.Load();//loads saved data from file
        //initialises a new game if no save data is found
        if (this.gameData == null)
        {
            Debug.Log("GameData is null, creating new GameData");
           NewGame();
           
        }
        foreach (ISaveData saveDataObj in saveDataObjects)
        {
            saveDataObj.LoadData(gameData);
        }
        Debug.Log("Loaded Game jumps =" + gameData.jumps);
        fileDataHandler.Save(gameData);

    }

    //function to create a new game 
    public void NewGame()
    {
        this.gameData = new GameData();
    }

    
    private List<ISaveData> FindAllDataPersistence()
    {
        //find all scripts that use the ISaveDta interface
        IEnumerable<ISaveData> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<ISaveData>();
        return new List<ISaveData>(dataPersistenceObjects); //returns a list of all the scripts that implement the interface
    }

}
