using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Data {

    // Player position is XYZ, but Vector3 is a Unity concept, so instead we store it as an array of floats.
    public float[] position;

    // A default constructor is used to create a blank Data object. These will be values on a new save.  
    public Data() {
        position = new float[3];
        position[0] = 0;
        position[1] = 0;
        position[2] = 0;
    }

    // A constructor is used to create a filled Data object. This version of the method creates a Data object from a passed GameState object. 
    public Data (GameState state) {
        position = new float[3];
        position[0] = state.playerPosition.x;
        position[1] = state.playerPosition.y;
        position[2] = state.playerPosition.z;
    }


}
