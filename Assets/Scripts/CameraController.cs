/*
    Code based on: http://answers.unity3d.com/questions/38526/smooth-follow-camera.html
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public GameObject player;
    public float heightDamping = 2.0f;
    public float rotationDamping = 0.5f;
    public float speedMultiplier = 0.05f;
    public float turnWaitTime = 2f;
    public float turnRecoveryTime = 2f;

    public float controllerSpeedVertical = 1f;
    public float controllerSpeedHorizontal = 1f;

    public float mouseSpeed = 1f;

    private float offset;
    private float lastTurnTime;

    // Use this for initialization
    void Start () {
        Vector3 offsetVector = transform.position - player.transform.position;
        offset = Vector3.Magnitude(offsetVector);
        lastTurnTime = Time.time - turnWaitTime;
    }

    // Update is called once per frame
    void LateUpdate () {
        // Get the current rotation of the camera
        float currentRotationAngleY = transform.eulerAngles.y;
        float currentRotationAngleX = transform.eulerAngles.x;

        // Get input
        float moveHorizontalController = Input.GetAxis("CameraHorizontal");
        float moveVerticalController = Input.GetAxis("CameraVertical");
        float moveHorizontalMouse = Input.GetAxis("Mouse X");
        float moveVerticalMouse = Input.GetAxis("Mouse Y");

        float timeSinceLastTurn = Time.time - lastTurnTime;

        if (moveHorizontalController != 0 || moveVerticalController != 0)
        {
            // Rotate based on controller thumbsticks
            currentRotationAngleY += moveHorizontalController * controllerSpeedHorizontal * Time.deltaTime;
            currentRotationAngleX += moveVerticalController * controllerSpeedVertical * Time.deltaTime;
            lastTurnTime = Time.time;
        }
        else if (moveHorizontalMouse != 0 || moveVerticalMouse != 0)
        {
            // Rotate based on mouse
            currentRotationAngleY += moveHorizontalMouse * mouseSpeed;
            currentRotationAngleX += moveVerticalMouse * mouseSpeed;
            lastTurnTime = Time.time;
        }
        else if (timeSinceLastTurn > turnWaitTime)
        {
            // Rotate camera towards player movement direction
            Vector3 velocity = player.GetComponent<Rigidbody>().velocity;
            velocity.y = 0;
            Quaternion playerDirection = Quaternion.LookRotation(velocity);
            float wantedRotationAngle = playerDirection.eulerAngles.y;

            // Calculate rotation speed
            float speed = Vector3.Magnitude(velocity) * Time.deltaTime * rotationDamping * speedMultiplier;
            float timeOverWaitTime = timeSinceLastTurn - turnWaitTime;
            if (timeOverWaitTime < turnWaitTime)
                speed *= timeOverWaitTime / turnWaitTime;

            // Lerp the Y angle rotation
            currentRotationAngleY = Mathf.LerpAngle(currentRotationAngleY, wantedRotationAngle, speed);
        }

        Quaternion currentRotation = Quaternion.Euler(currentRotationAngleX, currentRotationAngleY, 0);

        // Set camera behind the player based on rotation and initial offset
        Vector3 position = player.transform.position;
        position -= currentRotation * Vector3.forward * offset;
        transform.position = position;

        // Always look at the target
        transform.LookAt(player.transform);
    }
}
