using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver {
    
    [SerializeField] private List<TKey> keys = new List<TKey>();
    [SerializeField] private List<TValue> values = new List<TValue>();

    public void OnBeforeSerialize() {

        // Clear our keys and values lists.
        keys.Clear();
        values.Clear();

        // Loop through each list item and add them to respective lists. 
        foreach(KeyValuePair<TKey, TValue> pair in this) {
            keys.Add(pair.Key);
            values.Add(pair.Value);
        }

    }

    public void OnAfterDeserialize() {
        this.Clear();

        if (keys.Count != values.Count) {
            Debug.LogError("When attempting to deserialize keys and values, key amount " + keys.Count + " did not match value amount " + values.Count);
        }


        // Add deserialized keys and values to SerializableDictionary object.
        for (int i = 0; i < keys.Count; i++) {
            this.Add(keys[i], values[i]);
        }
    }

}
