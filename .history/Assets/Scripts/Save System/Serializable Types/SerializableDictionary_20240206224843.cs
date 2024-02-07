using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver {
    
    public void OnBeforeSerialize() {

    }

    public void OnAfterSerialize() {
        
    }

}
