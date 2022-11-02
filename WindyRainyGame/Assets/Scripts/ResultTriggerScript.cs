using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultTriggerScript : MonoBehaviour
{
    [SerializeField] hollow.StarAnimation starAnimation;
    [SerializeField] int needToWin;
    [SerializeField] int TwoStars;
    [SerializeField] int ThreeStars;
    TextMesh txt;
    int current = 0;
    bool startChecking = false;
    
    void Start()
    {
        txt = gameObject.GetComponentInChildren<TextMesh>();
        txt.text = current.ToString() + "/" + needToWin.ToString();
    }

    void Update()
    {
        //WinCondition
        if (!GameObject.FindGameObjectWithTag("drop") && startChecking)
        {
            if (current >= needToWin)
            {
                Stats.stagePassedToday++;
                Stats.ballsCollected += current;
            }
            //������ ������ (1 ������)
            starAnimation.gameObject.SetActive(true);
            starAnimation.OnWinStars(current, needToWin, TwoStars, ThreeStars);
            startChecking = false;
            //��������� ������� ������
            //������� ���-������
        }
    }
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "drop")
        {
            Destroy(collision.gameObject);
            current++;
            if (current == needToWin) OnWin();
            txt.text = current.ToString() + "/" + needToWin.ToString();
            startChecking = true;
        }
    }

   
    private void OnWin()
    {
       var componentAnimator = GetComponent<Animator>();
        componentAnimator.SetTrigger("WinParticle");
    }
    
}
