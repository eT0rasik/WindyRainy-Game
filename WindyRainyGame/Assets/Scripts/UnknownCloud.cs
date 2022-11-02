using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnknownCloud : MonoBehaviour
{
    [SerializeField ]int type;   //1 - умножение
                                 //2 - вычетание
    [SerializeField] int multiplier = 5;
    [SerializeField] int minusAmount = 4;
    int currentMinus = 0;
    private GameObject drop;
    [SerializeField] float rangeX = 0.5f;
    TextMesh txt;
    SpriteRenderer sprite;
    [SerializeField] Sprite CLB;
    [SerializeField] Sprite CLO;
    private bool passed = false;
    // Start is called before the first frame update
    void Start()
    {
        //В начале происходит смена тега в зависимоти от типа облака
        //Но в первоначально должен стоять тег "cloud"
        txt = gameObject.GetComponentInChildren<TextMesh>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
        switch (type)
        {
            case 2:
                {
                    gameObject.tag = "minusCloud";
                    break;
                }
            case 1:
                {
                    gameObject.tag = "cloud";
                    break;
                }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "drop")
        {
            switch (type)
            {
                case 1:
                    {
                        sprite.sprite = CLB;
                        txt.text = "x" + multiplier.ToString();
                        //Stats.SetPassedX(multiplier);
                        if (!passed)
                        {
                            Stats.IncreasePassedX(multiplier);
                            passed = true;
                        }
                        break;
                    }
                case 2:
                    {
                        sprite.sprite = CLO;
                        Destroy(collision.gameObject);
                        currentMinus++;
                        txt.text = "-" + (minusAmount - currentMinus).ToString();
                        if (currentMinus == minusAmount)
                        {
                            Destroy(gameObject);
                        }
                        //Stats.minusPassed = true;
                        if (!passed)
                        {
                            Stats.minusPassedTimes++;
                            passed = true;
                        }
                        break;
                    }
            }
        }
    }



    IEnumerator SpawnDrops()
    {
        Vector3 dropsPosition = gameObject.transform.position;
        dropsPosition.y -= gameObject.transform.localScale.y * 2;
        for (int i = 1; i < multiplier; ++i)
        {
            dropsPosition.x += Random.Range(rangeX * (-1), rangeX);
            yield return new WaitForSeconds(0.02f);
            Instantiate(drop, dropsPosition, gameObject.transform.rotation);
        }
    }

    public void Spawn(GameObject other)
    {
        if (other.tag == "drop")
        {
            Debug.Log("Start spawning");
            drop = other;
            StartCoroutine("SpawnDrops");
        }
    }
}
