using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoader : MonoBehaviour
{


    private Storage storage;
    private GameData gameData;

    private void Awake()
    {

        storage = new Storage();
        gameData = (GameData)storage.Load(new GameData());
        Debug.Log("stars: " + gameData.stars);
        Debug.Log("level: " + gameData.levels);
        Debug.Log("Skin: " + gameData.skinName);
        Debug.Log("Task1: " + gameData.task1.progress);
        Debug.Log("Task2: " + gameData.task2.progress);
        Debug.Log("Task3: " + gameData.task3.progress);

    }
    public void Save()
    {
        storage.Save(gameData);
    }
    public void SetData(GameData data)
    {
        gameData = data;
    }
    public GameData GetGameData(){
        return gameData;
    }
    public int GetLevels()
    {
        return gameData.levels;
    }
    public int GetStars()
    {
        return gameData.stars;
    }
    public string GetSkinName()
    {
        return gameData.skinName;
    }
    public List<Task> GetTasks()
    {
        List<Task> task = new List<Task>();
        task.Add(gameData.task1);
        task.Add(gameData.task2);
        task.Add(gameData.task3);
        return task;
    }
    public void ResetData()
    {
        storage.Save(new GameData());
    }
}
