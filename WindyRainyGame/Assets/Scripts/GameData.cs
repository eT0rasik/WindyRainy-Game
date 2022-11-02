using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class GameData 
{

    public int levels;
    public int stars;

    public Task task1;
    public Task task2;
    public Task task3;

    public string skinName;
    public GameData()
    {
        levels = 1;
        stars = 0;
        skinName = "Ball";
        task1 = new Task();
        task2 = new Task();
        task3 = new Task();
    }
}
