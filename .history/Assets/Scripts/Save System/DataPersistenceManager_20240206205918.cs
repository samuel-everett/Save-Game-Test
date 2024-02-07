using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistenceManager : MonoBehaviour {

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
    }

    public void SaveGame() {

    }

    private List<IDataPersistence> FindAllDataPersistenceObjects() {

        // Find all objects that inherit from both Monobehavior and IDataPersistence.
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistenceObjects);
    }

    private void OnApplicationQuit() {
        SaveGame();
    }
    
}
