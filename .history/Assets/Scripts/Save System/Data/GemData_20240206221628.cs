using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemData : MonoBehaviour, IDataPersistence {
    

    // Load position XYZ from our Data object.
    public void LoadData(Data data) {
        transform.position = new Vector3(data.position[0], data.position[1], data.position[2]);

        Debug.Log("Loading player position: " + transform.position);
    }

    // Save position XYZ to our Data object.
    public void SaveData(ref Data data) {
        data.position[0] = transform.position.x;
        data.position[1] = transform.position.y;
        data.position[2] = transform.position.z;

        Debug.Log("Saving player position: " + transform.position);
    }

}
