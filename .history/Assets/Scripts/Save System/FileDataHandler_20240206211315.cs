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
    }

}
