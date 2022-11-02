using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskMenu : MonoBehaviour
{
    [SerializeField] private SaveLoader save;
    [SerializeField] private StarCounter starCounter;
    [SerializeField] private PauseManager pause;
    private TaskComponent[] taskComponents;

    private List<Task> tasksSaved ;
    private bool isPaused =false;

    private void  OnEnable()
    {
        taskComponents = GetComponentsInChildren<TaskComponent>();
        LoadTasks();
        UpdateProgress();
        
    }
    private void Awake()
    {
        taskComponents = GetComponentsInChildren<TaskComponent>();
        LoadTasks();
        Init();
    }
    private void LoadTasks()
    {
        tasksSaved = save.GetTasks();
        for (int i = 0; i < taskComponents.Length; i++)
        {
            if(tasksSaved[i] is null){
                taskComponents[i].task = new Task();
                continue;
            }
            taskComponents[i].task = tasksSaved[i];
        }
    }
    public void Init()
    {
        foreach (var task in taskComponents)
        {
            task.InitValues();
        }
    }

    public void UpdateProgress()
    {
        for (int i = 0; i < taskComponents.Length; i++)
        {
            taskComponents[i].UpdateValues();
        }
        Stats.ResetStats();
        
    }
    public void SaveTasks()
    {
        UpdateProgress();
        GameData gameData = save.GetGameData();
        gameData.task1 = taskComponents[0].task;
        gameData.task1.progress = taskComponents[0].Progress;

        gameData.task2 = taskComponents[1].task;
        gameData.task2.progress = taskComponents[1].Progress;

        gameData.task3 = taskComponents[2].task;
        gameData.task3.progress = taskComponents[2].Progress;

        save.SetData(gameData);
        save.Save();
    }
    public void GenerateTasks()
    {
        List<Task> taskList = TaskJSONParser.LoadTasks();
        for (int i = 0; i < taskComponents.Length; i++)
        {
            int index = (int)Random.Range(0, taskList.Count);
            taskComponents[i].task = taskList[index];
            tasksSaved[i] = taskList[index];
        }
        SaveTasks();
        Init();

    }
    private void ReGenerateTask(TaskComponent taskComponent)
    {
        List<Task> taskList = TaskJSONParser.LoadTasks();
        var taskIndex = FindTaskComponent(taskComponent);
        int index = (int)Random.Range(0, taskList.Count);
        taskComponent.task = taskList[index];
        tasksSaved[taskIndex] = taskList[index];
        SaveTasks();
        Init();
        Stats.ResetStat(taskComponent.task.type);
    }
    private int FindTaskComponent(TaskComponent taskComponent){
        for(int i=0;i<tasksSaved.Count;i++){
           if(tasksSaved[i].title == taskComponent.task.title)
           return i;
        }
        return 0;
    }

    public void CollectStars(TaskComponent taskComponent){
        int reward = taskComponent.task.reward;
        StartCoroutine(StartStarAnimation(reward));
        ReGenerateTask(taskComponent);
        
    }
     private IEnumerator StartStarAnimation(int starsAmount)
        {
            if(Time.timeScale ==0f){
                isPaused = true;
                Time.timeScale = 1f;

            }
            var starCounterAnimator =starCounter.GetComponent<Animator>();
            for (int i = 0; i < starsAmount; i++)
            {
                yield return new WaitForSeconds(0.5f);
                starCounterAnimator.SetTrigger("Count");
                starCounter.Increment();
            }
            starCounter.SaveStars();
            if(isPaused){
                Time.timeScale = 0;
            }
            yield break;
        }

}
