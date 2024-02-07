using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour, IDataPersistence {
    
    public void LoadData(Data data) {
        transform.position = new Vector3(data.position[0], data.position[1], data.position[2]);
    }

    public void SaveData(ref Data data) {

    }


}
