using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject player;

    void Awake() {
        LoadGame();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
    }  

    // Handle loading here.
    void LoadGame() {
        Data data = SaveSystem.LoadData();
        player.transform.position = new Vector3 (data.position[0], data.position[1], data.position[2]);
    }

    void OnApplicationQuit() {
        Debug.Log("Saving");
        SaveSystem.SaveData(GameObject.Find("GameState").GetComponent<GameState>());
    }

}
