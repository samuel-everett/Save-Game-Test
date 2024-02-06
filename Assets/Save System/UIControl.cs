using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIControl : MonoBehaviour {

    public void LoadGame() {
        SceneManager.LoadScene("Level");
    }

    public void NewGame() {
        //SaveSystem.SaveData();
        SceneManager.LoadScene("Level");
    }
    
}
