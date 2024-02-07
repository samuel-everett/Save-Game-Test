using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance {get; private set; }

    // Singleton classes should only have one instance.. 
    private void Awake() {
        if (instance != null) {
            Debug.LogError("Duplicate Audio Managers...");
        }

        instance = this;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Debug.Log("Going to main menu.");
            Menu();
        }
    }

    public void Menu() {
        DataPersistenceManager.instance.SaveGame();
        SceneManager.LoadScene("Menu");
    }
}
