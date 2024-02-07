using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemData : MonoBehaviour {

    [SerializeField] private string id;


    // A guid is a string of 32 characters that has a high probability of being unique.
    // We can generate them to easily differentiate collectibles.

    // Context menu will us right click the GemData component and select this method as an option.
    [ContextMenu("Generate guid for id")]
    private void GenerateGuid() {
        id = System.Guid.NewGuid().ToString();
    }

}
