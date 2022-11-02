using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMinus : MonoBehaviour
{
    [SerializeField] int minusAmount = 10;
    int currentMinus = 0;
    TextMesh txt;
    private bool passed;
    // Start is called before the first frame update
    void Start()
    {
        txt = gameObject.GetComponentInChildren<TextMesh>();
        txt.text = "-" + minusAmount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "drop")
        {
            //Stats.minusPassed = true;
            if (!passed)
            {
                Stats.minusPassedTimes++;
                passed = true;
            }
            GetComponent<Animator>().SetTrigger("React");
            Destroy(collision.gameObject);
            currentMinus++;
            txt.text = "-" + (minusAmount - currentMinus).ToString();
            if (currentMinus == minusAmount)
            {
                Destroy(gameObject);
            }
        }
    }
}
