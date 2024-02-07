using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPersistenceManager : MonoBehaviour {

    public static DataPersistenceManager instance {get; private set; }


    // Singleton classes should only have one instance.. 
    private void Awake() {
        if (instance != null) {
            Debug.LogError("Duplicate Data Persistence Managers...");
        }

        instance = this;
    }

    public void NewGame() {
        this.gameData = new Data();
    }

    public void LoadGame() {

    }

    public void SaveGame() {

    }
    
}
