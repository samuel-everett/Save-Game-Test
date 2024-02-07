using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Data {

    // Player position.
    public Vector3 position;

    public SerializableDictionary<string, bool> gemsCollected;

    // A default constructor is used to create a blank Data object.
    public Data() {
        position = Vector3.zero;
        gemsCollected = new SerializableDictionary<string, bool>();
    }
    
}
