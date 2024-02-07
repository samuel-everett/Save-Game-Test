using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemData : MonoBehaviour, IDataPersistence {

    [SerializeField] private string id;
    private bool collected = false;

    // A guid is a string of 32 characters that has a high probability of being unique.
    // We can generate them to easily differentiate collectibles.

    // Context menu will us right click the GemData component and select this method as an option.
    [ContextMenu("Generate guid for id")]
    private void GenerateGuid() {
        id = System.Guid.NewGuid().ToString();
    }

    public void LoadData(Data data) {
        data.gemsCollected.TryGetValue(id, out collected);

        if (collected) {
            GetComponent<Gem>().collected = collected;
            gameObject.SetActive(false);
        }
    }

    public void SaveData(ref Data data) {
        
        if (data.gemsCollected.ContainsKey(id)) {
            data.gemsCollected.Remove(id);
        }

        data.gemsCollected.Add(id, GetComponent<Gem>().collected);

    }

}
