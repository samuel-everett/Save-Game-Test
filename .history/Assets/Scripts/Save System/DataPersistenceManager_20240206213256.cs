using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistenceManager : MonoBehaviour {

    [Header("File Storage Config")]


    public static DataPersistenceManager instance {get; private set; }
    private Data data;
    private List<IDataPersistence> dataPersistenceObjects;

    // Singleton classes should only have one instance.. 
    private void Awake() {
        if (instance != null) {
            Debug.LogError("Duplicate Data Persistence Managers...");
        }

        instance = this;
    }

    private void Start() {
        
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);

        // Fill out list of objects that will be saving and loading data.
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();

        LoadGame();
    }

    public void NewGame() {
        this.data = new Data();
    }

    public void LoadGame() {

        if (this.data  == null) {
            Debug.Log("No save game found. Creating new game.");
            NewGame();
        }

        // Loop through every object that stores data and call its LoadData() method.
        foreach (IDataPersistence dataPersistenceObject in dataPersistenceObjects) {
            dataPersistenceObject.LoadData(data);
        }

        Debug.Log("Loading...");

    }

    public void SaveGame() {

        // Loop through each data saving object and call its SaveData() method.
        foreach (IDataPersistence dataPersistenceObject in dataPersistenceObjects) {
            dataPersistenceObject.SaveData(ref data);
        }

        Debug.Log("Saving...");

    }

    private List<IDataPersistence> FindAllDataPersistenceObjects() {

        // Find all objects that inherit from both Monobehavior and IDataPersistence.
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();

        // Return the list.
        return new List<IDataPersistence>(dataPersistenceObjects);
    }

    private void OnApplicationQuit() {
        SaveGame();
    }
    
}
