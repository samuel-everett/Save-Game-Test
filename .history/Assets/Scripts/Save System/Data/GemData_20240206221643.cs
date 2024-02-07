using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemData : MonoBehaviour, IDataPersistence {
    

    // Load position XYZ from our Data object.
    public void LoadData(Data data) {
        
    }

    // Save position XYZ to our Data object.
    public void SaveData(ref Data data) {
        data.position[0] = transform.position.x;
        data.position[1] = transform.position.y;
        data.position[2] = transform.position.z;

        Debug.Log("Saving player position: " + transform.position);
    }

}
