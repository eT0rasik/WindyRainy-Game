using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private Transform fingerStart;
    [SerializeField] private Transform fingerSwipe;
    [SerializeField] int ballsAmount = 5;
    [SerializeField] float timeBetweenSpawns = 3.0f;
    private float TimeLeft;
    [SerializeField] public GameObject ball;
    [SerializeField] bool[] activatedMarks;
    [SerializeField] float rangeX = 0.5f;
    private int spawnedBalls = 0;
    bool spawn = false;
    private bool fingerAllowed = true;
    // Start is called before the first frame update
    void Start()
    {
        TimeLeft = timeBetweenSpawns;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBetweenSpawns <= TimeLeft && spawn)
        {
            Vector3 dropsPosition = gameObject.transform.position;
            dropsPosition.y -= gameObject.transform.localScale.y * 2;
            dropsPosition.x += Random.Range(rangeX * (-1), rangeX);
            TimeLeft = 0;
            ball.GetComponent<ilya.DropBehavior>().SetActivated(activatedMarks);
            var item = Instantiate(ball, dropsPosition, gameObject.transform.rotation); //.GetComponent<ilya.DropBehavior>().SetActivated(activatedMarks);
           item.tag = "drop";
            spawnedBalls++;
            if (spawnedBalls == ballsAmount)
            {
                Destroy(gameObject);
            }
        }
        TimeLeft += Time.deltaTime;
    }

    public void setActivatedMarks(bool[] marks)
    {
        activatedMarks = marks;
    }

    private void OnMouseDown()
    {
        spawn = true;
        if (fingerAllowed)
        {
                if(fingerStart!=null) fingerStart.gameObject.SetActive(false);
                if (fingerSwipe != null)
                {
                    fingerSwipe.gameObject.SetActive(true);
                    StartCoroutine(fingerSwipe.gameObject.GetComponent<FingerSwipe>().close());
                }
            fingerAllowed = false;
        }
    }
   
}
