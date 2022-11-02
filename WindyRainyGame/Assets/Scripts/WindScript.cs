using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindScript : MonoBehaviour
{
    [SerializeField] bool Left;
    [SerializeField] bool right;
    [SerializeField] float force;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "drop")
        {
            GameObject drop = collision.gameObject;
            var dropRB = drop.GetComponent<Rigidbody2D>();
            if (Left)
            {
                dropRB.AddForce(new Vector2(force * (-1), 0));
            }
            if (right)
            {
                dropRB.AddForce(new Vector2(force, 0));
            }
        }
    }
}
