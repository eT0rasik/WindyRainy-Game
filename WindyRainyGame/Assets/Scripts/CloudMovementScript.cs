using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovementScript : MonoBehaviour
{
    [SerializeField] float leftORright = 1;
    [SerializeField] float speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(speed * leftORright, 0);
        gameObject.GetComponent<Rigidbody2D>().velocity = movement; 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "drop")
        {
            leftORright = 0;
        }
        else
        {
            leftORright *= (-1);
        }
    }
}
