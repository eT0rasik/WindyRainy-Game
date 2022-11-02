using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointCloudBehavior : MonoBehaviour
{
    TextMesh txt;
    int current = 0;
    float r = 1f, g = 1f, b = 1f;
    private Color newColor;
    [SerializeField] float changingColor = 0.0025f;
    bool spawn = false;
    private float TimeLeft;
    
    [SerializeField] private SceneController sceneController;
    [SerializeField] private Transform WinTrigger;
    [SerializeField] private Transform Stage0;
    [SerializeField] private Transform Stage1;
    [SerializeField] private StageChange StageUI;
    [SerializeField] float timeBetweenSpawns = 0.05f;
    [SerializeField] public GameObject ball;
    [SerializeField] float rangeX = 0.5f;
    //[SerializeField] float TimetoWait = 10f;
    [SerializeField] bool[] activatedMarks;
    //float Timecounted;
    bool startChecking = false;
    private bool isSpawnReady = false;
    BoxCollider2D collider;
    // Start is called before the first frame update
    void Start()
    {
        txt = gameObject.GetComponentInChildren<TextMesh>();
        txt.text = current.ToString();
        TimeLeft = timeBetweenSpawns;
        collider = GetComponent<BoxCollider2D>();
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
            current--;
            txt.text = current.ToString();
            r = g = b = r + changingColor;
            newColor = new Color(r, g, b, 1f);
            GetComponent<Renderer>().material.color = newColor;
            if (current <= 0)
            {
                Destroy(gameObject);
            }
        }
        TimeLeft += Time.deltaTime;

        //WinCondition

        if (!GameObject.FindGameObjectWithTag("drop") && startChecking)
        {
            hollow.SceneTranslation.Instance.gameObject.GetComponent<Animator>().SetTrigger("Black");
            Stats.stagePassedToday++;
            Stats.ballsCollected = current;
            StartCoroutine(ChangeStage());
            StopCoroutine(ChangeStage());
            startChecking = false;
            isSpawnReady = true;
            Vector2 newsize;
            newsize.x = 25f;
            newsize.y = 72f;
            collider.size = newsize;
            Vector2 newoffset;
            newoffset.y = -35f;
            newoffset.x = 0;
            collider.offset = newoffset;
        }
    }

    private IEnumerator ChangeStage()
    {
        yield return new WaitForSeconds(1);
        Stage0.gameObject.SetActive(false);
        Stage1.gameObject.SetActive(true);
        WinTrigger.gameObject.SetActive(true);
        var transform = GetComponent<Transform>();
        var pos = transform.position;
        transform.position = new Vector3(pos.x, 8f, pos.z);
        hollow.SceneTranslation.Instance.gameObject.GetComponent<Animator>().SetTrigger("Transparent");
        GetComponent<BoxCollider2D>().isTrigger = true;
        sceneController.Init();
        StageUI.ChangeStage();

        yield return null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "drop" && !spawn)
        {
            Destroy(collision.gameObject);
            current++;
            txt.text = current.ToString();
            r = g = b = r - changingColor;
            newColor = new Color(r, g, b, 1f);
            GetComponent<Renderer>().material.color = newColor;
            startChecking = true;
        } 
    }

    private void OnMouseDown()
    {
        if (isSpawnReady)
        {
            spawn = true;
            collider.enabled = false;
        }
    }

    public void setActivatedMarks(bool[] marks)
    {
        activatedMarks = marks;
    }
}


