using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int movementSpeed;
    public Vector3 xzMovement;
    public float moveHorizontal;
    public float moveVertical;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        GetMovementInput();
    }

    void GetMovementInput()
    {
        if(Input.GetKey("w")|| Input.GetAxisRaw("Vertical") < -0.4)
        {
            xzMovement += transform.forward;
        }
        if (Input.GetKey("a") || Input.GetAxisRaw("Horizontal") < -0.4 )
        {
            xzMovement -= transform.right;
        }
        if (Input.GetKey("s") || Input.GetAxisRaw("Vertical") > 0.4)
        {
            xzMovement -= transform.forward;
        }
        if (Input.GetKey("d") || Input.GetAxisRaw("Horizontal") > 0.4)
        {
            xzMovement += transform.right;
        }
        if(xzMovement == new Vector3(0,0,0))
        {
            rb.velocity = new Vector3(0,rb.velocity.y,0);
        }
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");
        transform.position += xzMovement * Time.deltaTime * movementSpeed;
        xzMovement = new Vector3(0, 0, 0);
    }

}
