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

        string fullPath = Path.Combine(path, fileName);

        Data loadedData = null;

        if (File.Exists(fullPath)) {

            try {

                // Load serialized data from the file.
                string dataToLoad = "";
                

                // Read from the file.
                using (FileStream stream = new FileStream(fullPath, FileMode.Open)) {

                    using (StreamReader reader = new StreamReader(stream)) {

                        dataToLoad = reader.ReadToEnd();

                    }

                }


            } catch (Exception e) {



            }

        }

        return loadedData;

    }

    public void Save(Data data) {

        string fullPath = Path.Combine(path, fileName);

        try {

            // Create the directory to store the data if it isn't found.
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            // Serialize the game data into a Json.
            string jsonData = JsonUtility.ToJson(data, true);

            // Write data to file.
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
