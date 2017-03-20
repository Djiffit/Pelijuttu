/*
    Code based on: http://answers.unity3d.com/questions/38526/smooth-follow-camera.html
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public GameObject player;
    public float speed = 100;

    private float offsetHorizontal;
    private float offsetVertical;
    private float xRotation;

    float heightDamping = 2.0f;
    float rotationDamping = 3.0f;

    // Use this for initialization
    void Start () {
        Vector3 offset = transform.position - player.transform.position;
        offsetHorizontal = Vector3.Magnitude(new Vector3(offset.x, 0f, offset.y));
        offsetVertical = offset.y;
        xRotation = transform.rotation.eulerAngles.x;
	}
	
	// Update is called once per frame
	void LateUpdate () {

        // Calculate the current rotation angles
        Vector3 velocity = player.GetComponent<Rigidbody>().velocity.normalized;
        Quaternion lookRotation = Quaternion.LookRotation(velocity);
        float wantedRotationAngle = lookRotation.eulerAngles.y;
        float wantedHeight = player.transform.position.y + offsetVertical;
        float currentRotationAngle = transform.eulerAngles.y;
        float currentHeight = transform.position.y;
        // Damp the rotation around the y-axis
        currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);
        // Damp the height
        currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);
        // Convert the angle into a rotation
        Quaternion currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);
        // Set the position of the camera on the x-z plane to:
        // distance meters behind the target
        Vector3 position = player.transform.position;
        position -= currentRotation * Vector3.forward * offsetHorizontal;
        position.y = currentHeight;
        // Set the height of the camera
        transform.position = position;
        // Always look at the target
        transform.LookAt(player.transform);
    }
}
