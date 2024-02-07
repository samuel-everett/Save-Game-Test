using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveSystem {


    // This method will save our data. 
    public static void SaveData(GameState state) {

        // Used to write our data in binary format. 
        BinaryFormatter formatter = new BinaryFormatter();

        // Path is a system path where the data will be saved. We can use whatever extension we want, since it's our own unique data type.
        string path = Application.persistentDataPath + "/COINGRABBER.slay";

        // The FileStream object lets us write to a location. FileMode.Create will create a new file in the location (path).
        FileStream stream = new FileStream(path, FileMode.Create);

        // Use the constructor to create a new Data object. 
        Data data = new Data(state);

        // Serialize encodes the data.
        formatter.Serialize(stream, data);

        // Be sure to close the stream when we're done! 
        stream.Close();
    }

    public static void CreateNewGame() {

        // Used to write our data in binary format. 
        BinaryFormatter formatter = new BinaryFormatter();

        // Path is a system path where the data will be saved. We can use whatever extension we want, since it's our own unique data type.
        string path = Application.persistentDataPath + "/COINGRABBER.slay";

        // Open file stream.
        FileStream stream = new FileStream(path, FileMode.CreateNew);
        
        // Create new BLANK Data object. 
        Data data = new Data();

        // Serialize encodes the data. 
        formatter.Serialize(stream, data);

        stream.Close();

    }


    // This method will load our data.
    public static Data LoadData() {

        // Locate our save file.
        string path = Application.persistentDataPath + "COINGRABBER.slay";

        if (File.Exists(path)) {

            // Our formatter will be used to deserialize our data. 
            BinaryFormatter formatter = new BinaryFormatter();

            // Create a file stream to access the save data file.
            FileStream stream = new FileStream(path, FileMode.Open);

            // Deserialize data as a Data object. 
            Data data = formatter.Deserialize(stream) as Data;

            // Close our stream.
            stream.Close();
            
            // Return our data object.
            return data;

        } else {

            // If we can't locate the save file, report it. 
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

}
