using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Движение как по драуг, так и ускорение от свайпов
public class DropMovementScript : MonoBehaviour
{
    [SerializeField] float Force;
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
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Debug.Log("Touch Fixed");
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            touchDeltaPosition.x *= Force;
            touchDeltaPosition.y = 0;
            gameObject.GetComponent<Rigidbody2D>().AddForce(touchDeltaPosition);
        }
        if (transform.position.y < -5.7)
        {
            GetComponent<DropMovementScript>().enabled = false;
        }
    }
}
