using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMultiplier : MonoBehaviour
{
    [SerializeField] int multiplier = 20;
    private GameObject drop;
    [SerializeField] float rangeX = 0.5f;
    TextMesh txt;
    private bool passed;
    void Start()
    {
        txt = gameObject.GetComponentInChildren<TextMesh>();
        txt.text = "x" + multiplier.ToString();
    }

    // Update is called once per frame
    void Update()
    {

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
            //Debug.Log("Start spawning");
            //Stats.SetPassedX(multiplier);
            if (!passed)
            {
                Stats.IncreasePassedX(multiplier);
                passed = true;
            }
            drop = other;
            StartCoroutine("SpawnDrops");
        }
    }
}
