using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour {
    
    public bool collected = false;

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            collected = true;
            gameObject.SetActive(false)''
        }
    }

}
