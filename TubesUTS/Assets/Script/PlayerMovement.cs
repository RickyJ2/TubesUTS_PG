using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float velocity = 5f;
    [SerializeField] float acceleration = 3f;
    [SerializeField] float rotationSpeed = 30f;

    private Quaternion targetRotation;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        targetRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            targetRotation *= Quaternion.AngleAxis(-rotationSpeed * Time.deltaTime, Vector3.up);
        }
        if (Input.GetKey(KeyCode.X))
        {
            targetRotation *= Quaternion.AngleAxis(rotationSpeed * Time.deltaTime, Vector3.up);
        }

        transform.rotation = targetRotation;
        Vector3 movementDirection = transform.forward;

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        rb.velocity = movementDirection * verticalInput * velocity + transform.right * horizontalInput * velocity;

        //Sprint
        if (Input.GetKeyDown("space"))
        {
            velocity *= acceleration;
        }
        //Stop Sprint
        if (Input.GetKeyUp("space"))
        {
            velocity /= acceleration;
        }
    }
}
