using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace hollow
{
    public class StarAnimation : MonoBehaviour
    {


        [SerializeField] private GameObject StarsBase;
        [SerializeField] private Animator UILose;
        [SerializeField] private StarCounter StarCount;
        [SerializeField] private float delayInSeconds = 1f;
        private Animator[] stars;
        private bool isReady = false;


        private void Awake()
        {
            stars = StarsBase.GetComponentsInChildren<Animator>();
            Debug.Log("starAmount " + stars.Length);

        }



        private IEnumerator StartStarAnimation(int starsAmount)
        {
            var starCounter = StarCount.GetComponent<Animator>();
            while(!isReady){yield return new WaitForSeconds(1f);    }

            if (starsAmount > stars.Length) starsAmount = stars.Length;

            for (int i = 0; i < starsAmount; i++)
            {
                stars[i].SetTrigger("ToGrow");
                yield return new WaitForSeconds(delayInSeconds);
                starCounter.SetTrigger("Count");
                StarCount.Increment();
            }
        }

        public void OnWinStars(int pointsCurrent, int pointsToWin, int pointsToTwoStars, int pointsToThreeStars)
        {
            int starsAmount = 0;
            if (pointsCurrent >= pointsToWin)
            {
                starsAmount++;
                if (pointsCurrent >= pointsToTwoStars)
                {
                    starsAmount++;
                    if (pointsCurrent >= pointsToThreeStars)
                    {
                        starsAmount++;
                    }
                }
                StartCoroutine(StartStarAnimation(starsAmount));
            }
            else
            {
                UILose.gameObject.SetActive(true);
            }

        }
        public void CollectStars(int count){
            StartCoroutine(StartStarAnimation(count));
        }
      
        public void setReady(){
            isReady = true;
        }
    }
}
