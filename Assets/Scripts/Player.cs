using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float maxSwingAngle;

    private Rigidbody2D rb;
    //private Quaternion targetRotate;
    private Vector2 moveVelocity;
    private float moveRotate;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //float current_x = rb.position.x;
        //float current_y = rb.position.y;
        //float current_rotation = rb.rotation;

        /*if (Input.GetKey(KeyCode.UpArrow) && current_y < maxY)
        {
           // rb.MoveRotation(-Time.deltaTime);
            targetRotate = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w + 5);
        }
        else if (Input.GetKey(KeyCode.DownArrow) && current_y > minY)
        {
            //rb.MoveRotation(Time.deltaTime);
            targetRotate = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w - 5);
        }*/

        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        moveVelocity = moveInput.normalized * speed;
        //moveRotate = moveInput.normalized.y * 100;
        
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
        //if (rb.rotation <= maxSwingAngle && rb.rotation >= -maxSwingAngle)
        //{
        //    rb.MoveRotation(rb.rotation + moveRotate * Time.fixedDeltaTime);
        //}
        //rb.rotation = rb.rotation / 1.001f;
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, new Quaternion(0, 0, 0, 0), 1000 * Time.deltaTime);
    }
}
