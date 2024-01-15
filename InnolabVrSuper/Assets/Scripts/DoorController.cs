using System;
using System.Collections;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Transform doorTransform; // Assign the transform of the door
    public float openAngle = -90.0f; // Angle the door should open to
    public float openSpeed = 2.0f; // How fast the door opens
    private bool isOpening = false;
    private Quaternion closedRotation;
    private Quaternion openRotation;

    void Start()
    {
        // Store the initial rotation of the door
        closedRotation = doorTransform.rotation;
        // Calculate the open rotation based on the initial rotation and the open angle
        openRotation = Quaternion.Euler(doorTransform.eulerAngles.x, doorTransform.eulerAngles.y + openAngle, doorTransform.eulerAngles.z);
        StartCoroutine(OpenDoorAfterDelay(5));

    }

    void Update()
    {
        // If the door is opening, slerp towards the open rotation
        if (isOpening)
        {
            doorTransform.rotation = Quaternion.Slerp(doorTransform.rotation, openRotation, Time.deltaTime * openSpeed);
        }
    }
    IEnumerator OpenDoorAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        isOpening = true; // Start opening the door
    }

}