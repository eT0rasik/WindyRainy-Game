using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace hollow
{
    public class SceneTranslation : MonoBehaviour
    {
        private static SceneTranslation instance;
        public static SceneTranslation Instance { get { return instance; } }
        private Animator componentAnimator;
        private AsyncOperation loadingOperation;
        private bool isPlaying = false;
        public static void SwitchToScene(string sceneName)
        {
            if(instance.isPlaying) return;
            instance.isPlaying = true;
            instance.componentAnimator.SetTrigger("Black");
            instance.loadingOperation = SceneManager.LoadSceneAsync(sceneName);
            instance.loadingOperation.allowSceneActivation = false;


        }
        // Start is called before the first frame update
        public void Start()
        {
            instance = this;

            componentAnimator = GetComponent<Animator>();
            componentAnimator.SetTrigger("Transparent");
        }
        public void OnAnimationOver()
        {
            if (loadingOperation != null)
            {
                loadingOperation.allowSceneActivation = true;
                instance.isPlaying = false;

            }
            else
            {
               
            }
        }
    }
}