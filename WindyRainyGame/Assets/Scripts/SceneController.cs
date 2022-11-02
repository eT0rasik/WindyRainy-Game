using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private bool[] activated;
    private GameObject[] clouds;
    private GameObject[] spawners;
    private BallSpawner ballSpawner;
    private CheckPointCloudBehavior checkPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Init()
    {
        clouds = GameObject.FindGameObjectsWithTag("cloud");

        activated = new bool[clouds.Length];
       
        for (int i = 0; i < clouds.Length; ++i)
        {
            activated[i] = false;
            clouds[i].AddComponent<IDSystem>();
            clouds[i].GetComponent<IDSystem>().SetId(i);
        }
        spawners = GameObject.FindGameObjectsWithTag("ballSpawner");
        for (int i = 0; i < spawners.Length; ++i)
        {
            if (spawners[i].TryGetComponent<BallSpawner>(out ballSpawner))
            {
                ballSpawner.setActivatedMarks(activated);
            }
            else if (spawners[i].TryGetComponent<CheckPointCloudBehavior>(out checkPoint))
            {
                checkPoint.setActivatedMarks(activated);
            }
        }
    }
}
