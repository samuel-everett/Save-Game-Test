using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class FileDataHandler {

    private string path = "";
    private string fileName = "";

    public FileDataHandler(string path, string fileName) {
        this.path = path;
        this.fileName = fileName;
    }

    public Data Load() {

    }

    public void Save(Data data) {

        string fullPath = Path.Combine(path, fileName);

        try {
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            // Serialize the game data into a Json.
            string jsonData = JsonUtility.ToJson(data, true);

            using (FileStream stream = new FileStream(fullPath, FileMode.Create)) {
                using (StreamWriter writer = new StreamWriter(stream)) {
                    writer.Write(jsonData);
                }
            }

        } catch(Exception e) {
            Debug.LogError("Error occured when trying to save data to file " + fullPath + "\n" + e);
        }
    }

}
