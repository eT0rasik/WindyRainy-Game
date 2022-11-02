using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class LevelController : MonoBehaviour
{

    [SerializeField] private SaveLoader save;
    [SerializeField] private StarCounter starCounter;
    [SerializeField] private BallSpawner spawner;
    [SerializeField] private TaskMenu taskMenu;
    [SerializeField] private int _level;

    private int level = 1;
    private bool isReady = true;

    private void Start() {
        var skin = Resources.Load<GameObject>("SkinPrefabs/"+save.GetSkinName());
        
    }
    
    public void Retry()
    {
        level = save.GetLevels();
        Debug.Log(level.ToString());
        hollow.SceneTranslation.SwitchToScene("Level_" + level.ToString());
        SaveTasks();
    }
    public void ReturnToMenu(){
        SaveTasks();
    }

    public void Continue()
    {
        if (!isReady) return;
        isReady = false;
        
        level = save.GetLevels();
        if(_level >= level){
            level = _level+1;
        }

        var data = save.GetGameData();

        if (_level >= 8)
        {
            data.levels = 8;
            save.SetData(data);
            save.Save();
            SaveTasks();
            hollow.SceneTranslation.SwitchToScene("MainMenu");
            return;
        }
        data.stars = starCounter.GetStars();
        data.levels = level;
        save.SetData(data);
        save.Save();
        SaveTasks();
        hollow.SceneTranslation.SwitchToScene("Level_" + level);

    }
    private void SaveTasks(){
        var parent = taskMenu.transform.parent.gameObject;
       parent.SetActive(true);
       taskMenu.SaveTasks();
       parent.SetActive(false);

    }
}
