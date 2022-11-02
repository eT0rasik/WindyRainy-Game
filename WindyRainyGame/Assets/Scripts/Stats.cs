using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    //Today
    public static int stagePassedToday = 0;
    public static int x1PassedTimes = 0;
    public static int x2PassedTimes = 0;
    public static int x3PassedTimes = 0;
    public static int x4PassedTimes = 0;
    public static int x5PassedTimes = 0;
    public static int x6PassedTimes = 0;
    public static int x7PassedTimes = 0;
    public static int minusPassedTimes = 0;
    //LastLevel
    public static int ballsCollected = 0;


    //LastScene
    /*
    public static bool x1Passed = false;
    public static bool x2Passed = false;
    public static bool x3Passed = false;
    public static bool x4Passed = false;
    public static bool x5Passed = false;
    public static bool x6Passed = false;
    public static bool x7Passed = false;
    public static bool minusPassed = false;
    */
    
    /*
    public static void SetPassedX(int multiplier)
    {
        switch (multiplier)
        {
            case 1: x1Passed = true; break;
            case 2: x2Passed = true; break;
            case 3: x3Passed = true; break;
            case 4: x4Passed = true; break;
            case 5: x5Passed = true; break;
            case 6: x6Passed = true; break;
            case 7: x7Passed = true; break;
        }
    }
    */

    public static void IncreasePassedX(int multiplier)
    {
        switch (multiplier)
        {
            case 1: x1PassedTimes++; break;
            case 2: x2PassedTimes++; break;
            case 3: x3PassedTimes++; break;
            case 4: x4PassedTimes++; break;
            case 5: x5PassedTimes++; break;
            case 6: x6PassedTimes++; break;
            case 7: x7PassedTimes++; break;
        }
    }

    public static void ResetStats()
    {
        stagePassedToday = 0;
        x1PassedTimes = 0;
        x2PassedTimes = 0;
        x3PassedTimes = 0;
        x4PassedTimes = 0;
        x5PassedTimes = 0;
        x6PassedTimes = 0;
        x7PassedTimes = 0;
        minusPassedTimes = 0;
        ballsCollected = 0;
    }

    public static void ResetStat(TaskType type){
        switch (type)
        {
            case TaskType.X1Passed:
                Stats.x1PassedTimes = 0;
                break;
            case TaskType.X2Passed:
                Stats.x1PassedTimes = 0;
                break;
            case TaskType.X3Passed:
                Stats.x1PassedTimes = 0;
                break;
            case TaskType.X4Passed:
                Stats.x1PassedTimes = 0;
                break;
            case TaskType.X5Passed:
                Stats.x1PassedTimes = 0;
                break;
            case TaskType.MinusPassed:
                Stats.x1PassedTimes = 0;
                break;
            case TaskType.BallsCollected:
                Stats.x1PassedTimes = 0;
                break;
            case TaskType.StagePassed:
                Stats.x1PassedTimes = 0;
                break;
        }
    }
}
