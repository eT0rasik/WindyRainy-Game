using System.Linq;
using System.IO;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TaskJSONParser
{

    public static void SaveTasks(List<Task> toSave)
    {
        string content = JsonHelper.ToJson<Task>(toSave.ToArray());
        string path = Application.persistentDataPath + "/JSONData/TaskStorage.json";
        WriteFile(path, content);

    }
    public static List<Task> LoadTasks()
    {
        string path = Application.persistentDataPath + "/JSONData/TaskStorage.json";
         string dir = Application.persistentDataPath + "/JSONData";
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
            if(!File.Exists(path)){
            return CreateDefault();

        }
        string content = ReadFile(path);
       
        if (string.IsNullOrEmpty(content) || content == "{}")
        {
            return CreateDefault();
        }
        List<Task> res = JsonHelper.FromJson<Task>(content).ToList();

        return res;
    }

    private static void WriteFile(string path, string content)
    {
        FileStream fileStream = new FileStream(path, FileMode.Create);
        using (StreamWriter writer = new StreamWriter(fileStream))
        {
            writer.Write(content);
        }
    }
    private static string ReadFile(string path)
    {
        if (File.Exists(path))
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string content = reader.ReadToEnd();
                return content;
            }
        }
        return "";
    }

    private static List<Task> CreateDefault()
    {
        List<Task> defaultList = new List<Task>();
        defaultList.Add(new Task(1, false, "Пролетите шариками через два облачка х2", 0, 2, 2, TaskType.X2Passed));
        defaultList.Add(new Task(2, false, "Соберите более 300 шариков", 0, 300, 3, TaskType.BallsCollected));
        defaultList.Add(new Task(3, false, "Соберите более 500 шариков", 0, 500, 5, TaskType.BallsCollected));
        defaultList.Add(new Task(1, false, "Проидите 4 этапа ", 0, 4, 2, TaskType.StagePassed));
        defaultList.Add(new Task(2, false, "Пролетите шариками через три облачка х2", 0, 3, 3, TaskType.X2Passed));
        defaultList.Add(new Task(3, false, "Пролетите шариками через пять облаков х3", 0, 5, 5, TaskType.X3Passed));
        defaultList.Add(new Task(1, false, "Соберите более 200 шариков", 0, 200, 2, TaskType.BallsCollected));
        defaultList.Add(new Task(2, false, "Проидите 6 этапов ", 0, 6, 3, TaskType.StagePassed));
        defaultList.Add(new Task(3, false, "Пролетите шариками через шесть облаков х4", 0, 6, 5, TaskType.X4Passed));
        defaultList.Add(new Task(1, false, "Пролетите шариками через одно облачко х3", 0, 1, 2, TaskType.X3Passed));
        defaultList.Add(new Task(2, false, "Соберите более 350 шариков", 0, 350, 3, TaskType.BallsCollected));
        defaultList.Add(new Task(3, false, "Проидите 8 этапов ", 0, 8, 5, TaskType.StagePassed));
        defaultList.Add(new Task(1, false, "Проидите 3 этапа ", 0, 3, 2, TaskType.StagePassed));
        defaultList.Add(new Task(2, false, "Пролетите шариками через три облачка х4", 0, 3, 3, TaskType.X4Passed));
        defaultList.Add(new Task(3, false, "Соберите более 600 шариков", 0, 600, 5, TaskType.BallsCollected));
        string path = Application.persistentDataPath + "/JSONData/TaskStorage.json";
        string content = JsonHelper.ToJson<Task>(defaultList.ToArray());
        WriteFile(path,content);
        return defaultList;
    }
    public static void ResetJSON(){
        CreateDefault();
    }

    public static class JsonHelper
    {
        public static T[] FromJson<T>(string json)
        {
            Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
            return wrapper.Items;
        }

        public static string ToJson<T>(T[] array)
        {
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.Items = array;
            return JsonUtility.ToJson(wrapper);
        }

        public static string ToJson<T>(T[] array, bool prettyPrint)
        {
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.Items = array;
            return JsonUtility.ToJson(wrapper, prettyPrint);
        }

        [Serializable]
        private class Wrapper<T>
        {
            public T[] Items;
        }
    }

}
