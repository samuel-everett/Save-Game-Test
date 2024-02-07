using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Data {

    // Player position.
    public Vector3 position;

    public Dictionary<string, bool> gemsCollected;

    // A default constructor is used to create a blank Data object. These will be values on a new save.  
    public Data() {
        position = Vector3.zero;
    }
    
}
