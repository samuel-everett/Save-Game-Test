using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data {

    // We store coins as true (collected) or false (uncollected)
    //public bool[] coins;

    // Player position is XYZ, but Vector3 is a Unity concept, so instead we store it as an array of floats.
    public float[] position;


    // A constructor is used to create a Data object. 
    public Data (GameState state) {
        position = new float[3];
        position[0] = state.playerPosition.x;
        position[1] = state.playerPosition.y;
        position[2] = state.playerPosition.z;
    }

    // A constructor is used to create a Data object. 
    public Data () {
        position = new float[3];
        position[0] = 0;
        position[1] = 0;
        position[2] = 0;
    }
}
