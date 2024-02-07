using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistenceManager : MonoBehaviour {

    [Header("File Storage Config")]
    [SerializeField] private string fileName;
    private FileDataHandler dataHandler;
    private Data data;
    private List<IDataPersistence> dataPersistenceObjects;


    public static DataPersistenceManager instance {get; private set; }


    // Singleton classes should only have one instance.. 
    private void Awake() {
        if (instance != null) {
            Debug.LogError("Duplicate Data Persistence Managers...");
        }

        instance = this;
    }

    private void Start() {
        

        // Create a new Data Handler (for reading from and writing to Json) with a directory
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);

        // Fill out list of objects that will be saving and loading data.
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();

        LoadGame();
    }

    public void NewGame() {
        Debug.Log("Starting new game..");
        this.data = dataHandler.NewGame();
    }

    public void LoadGame() {

        // Load saved data from the file. 
        this.data = dataHandler.Load();

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

        // Save the data object through our FileDataHandler object.
        dataHandler.Save(data);

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
