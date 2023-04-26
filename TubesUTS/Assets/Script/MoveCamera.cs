using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform player;
    [SerializeField] Vector3 rotationOffset;
    [SerializeField] float distanceFromPlayer;
    [SerializeField] float smoothness;

    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate() {
        // Calculate the new position and rotation of the camera
        Vector3 newPosition = player.position - transform.forward * distanceFromPlayer;
        float newYRotation = player.eulerAngles.y;
        Quaternion newRotation = Quaternion.Euler(new Vector3(rotationOffset.x, rotationOffset.y + newYRotation, rotationOffset.z));

        // Smoothly move the camera to the new position and rotation
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * smoothness);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * smoothness);
    }
}
