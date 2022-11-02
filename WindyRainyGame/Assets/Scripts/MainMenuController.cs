using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
namespace hollow
{
    public class MainMenuController : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField] private SaveLoader save;
        [SerializeField] private StarCounter starCounter;
        [SerializeField] private SkinsMenu skinsMenu;
        private string mainSceneName = "Level_1";

        

        void Start()
        {
            mainSceneName = "Level_" + save.GetLevels();
        }

        public void OnStartGame()
        {

            int level = save.GetLevels();
            Debug.Log(level);
            mainSceneName = "Level_" + level;
            SaveSkin();
            starCounter.SaveStars();
            SceneTranslation.SwitchToScene(mainSceneName);
        }

        private void SaveSkin()
        {
            string skinName = skinsMenu.GetSelectedSkin();
            GameData data = save.GetGameData();
            data.skinName = skinName;
            save.SetData(data);
            save.Save();
            skinsMenu.SaveSkin();
        }

        public void OnReset()
        {
            save.ResetData();
            Stats.ResetStats();
            TaskJSONParser.ResetJSON();
            SceneTranslation.SwitchToScene("MainMenu");

        }
        public void PlayLevel(int level){
            string sceneName = "Level_" + level;
            SaveSkin();
            starCounter.SaveStars();
            SceneTranslation.SwitchToScene(sceneName);
        }
      

    }
}