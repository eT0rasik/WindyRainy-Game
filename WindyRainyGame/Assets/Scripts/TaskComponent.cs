using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskComponent : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text title;
    [SerializeField] private TMPro.TMP_Text starCountText;
    [SerializeField] private GameObject completedPanel;
    private Slider progressBar;
    private TMPro.TMP_Text progressBarText;
    public int Progress => (int)progressBar.value;
    public Task task;

    private void Start()
    {
        progressBar = GetComponentInChildren<Slider>();
        progressBarText = progressBar.GetComponentInChildren<TMPro.TMP_Text>();
    }
    private void OnEnable(){
        progressBar = GetComponentInChildren<Slider>();
        progressBarText = progressBar.GetComponentInChildren<TMPro.TMP_Text>();
    }
    public void InitValues()
    {
        title.text = task.title;
        starCountText.text = task.reward.ToString();
        progressBar.maxValue = task.goal;
        progressBar.value = task.progress;
        progressBarText.text = task.progress.ToString() + "/" + task.goal.ToString();
        if (task.progress >= task.goal)
        {
            completedPanel.SetActive(true);
        }else{
            completedPanel.SetActive(false);
        }
    }
    
     public void UpdateValues()
    {
        title.text = task.title;
        starCountText.text = task.reward.ToString();
        progressBar.maxValue = task.goal;
        task.progress = task.progress + GetProgress(task.type);
        progressBar.value = task.progress; 
        progressBarText.text = progressBar.value.ToString() + "/" + task.goal.ToString();
        if (progressBar.value >= task.goal)
        {
            completedPanel.SetActive(true);
        }
    }
    public void ResetValues(){

    }
    private int GetProgress(TaskType type)
    {
        int res = 0;
        switch (type)
        {
            case TaskType.X1Passed:
                res = Stats.x1PassedTimes;
                break;
            case TaskType.X2Passed:
               res = Stats.x2PassedTimes;
                break;
            case TaskType.X3Passed:
                res = Stats.x3PassedTimes;
                break;
            case TaskType.X4Passed:
                res = Stats.x4PassedTimes;
                break;
            case TaskType.X5Passed:
                res = Stats.x5PassedTimes;
                break;
            case TaskType.MinusPassed:
               res = Stats.minusPassedTimes;
                break;
            case TaskType.BallsCollected:
                res = Stats.ballsCollected;
                break;
            case TaskType.StagePassed:
                res = Stats.stagePassedToday;
                break;
        }
        return res;
    }
   






}
