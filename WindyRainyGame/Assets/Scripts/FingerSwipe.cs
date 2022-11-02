using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerSwipe : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(close());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Destroy()
    {
        StartCoroutine(close());
       
    }

    public IEnumerator close()
    {
        yield return new WaitForSeconds(4);
        this.gameObject.SetActive(false);

    }
}
