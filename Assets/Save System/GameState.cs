using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour {
    public GameObject player;
    public Vector3 playerPosition;

    void Update() {
        playerPosition = player.transform.position;
    }
}
