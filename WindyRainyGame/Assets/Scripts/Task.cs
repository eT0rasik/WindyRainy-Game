

using System;

[Serializable]
public enum TaskType
{
    X1Passed = 1,
    X2Passed = 2,
    X3Passed = 3,
    X4Passed = 4,
    X5Passed = 5,
    StagePassed = 6,
    MinusPassed = 7,
    BallsCollected=8

}
[System.Serializable]
public class Task
{
    public int difficulty;
    public bool isAchieved;
    public string title;
    public int progress;
    public int goal;
    public int reward;
    public TaskType type;



    public Task()
    {
        difficulty = 0;
        isAchieved = false;
        title = "Empty task";
        progress = 0;
        goal = 100;
        reward = 0;
        type = TaskType.BallsCollected;
    }

    public Task(int difficulty, bool isAchieved, string title, int progress, int goal, int reward,  TaskType type)
    {
        this.difficulty = difficulty;
        this.isAchieved = isAchieved;
        this.title = title;
        this.progress = progress;
        this.goal = goal;
        this.reward = reward;
        this.type = type;
    }


  
}
