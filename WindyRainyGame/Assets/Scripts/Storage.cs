using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
public class Storage
{

    private string filePath;
    private BinaryFormatter formatter;
    public Storage()
    {
        formatter = new BinaryFormatter();
        filePath = Application.persistentDataPath + "/saves/Gamesave.save";

    }

    public object Load(object saveDataByDefault)
    {
        if (!File.Exists(filePath))
        {
            string dir = Application.persistentDataPath + "/saves";
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
            if (saveDataByDefault != null)
            {
                Save(saveDataByDefault);
            }
            return saveDataByDefault;
        }
        var file = File.Open(filePath, FileMode.Open);
        var savedData = formatter.Deserialize(file);
        file.Close();
        return savedData;
    }

    public void Save(object saveData)
    {
        var file = File.Create(filePath);
        formatter.Serialize(file, saveData);
        file.Close();
    }
}
