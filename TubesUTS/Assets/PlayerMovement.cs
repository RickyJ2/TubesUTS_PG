using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float velocity = 5f;
    [SerializeField] float acceleration = 3f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(horizontalInput * velocity, rb.velocity.y, verticalInput* velocity);

        //Sprint
        if (Input.GetButtonDown("Jump"))
        {
            velocity *= acceleration;
        }
        //Stop Sprint
        if (Input.GetButtonUp("Jump"))
        {
            velocity /= acceleration;
        }
    }
}
