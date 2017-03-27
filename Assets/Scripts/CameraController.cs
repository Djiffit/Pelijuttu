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

    private float offsetHorizontal;
    private float offsetVertical;

    // Use this for initialization
    void Start () {
        Vector3 offset = transform.position - player.transform.position;
        offsetHorizontal = Vector3.Magnitude(new Vector3(offset.x, 0f, offset.z));
        offsetVertical = offset.y;
	}
	
	// Update is called once per frame
	void LateUpdate () {

        // Calculate the current rotation angles
        Vector3 velocity = player.GetComponent<Rigidbody>().velocity;
        Quaternion lookRotation = Quaternion.LookRotation(velocity);
        float wantedRotationAngle = lookRotation.eulerAngles.y;
        float wantedHeight = player.transform.position.y + offsetVertical;
        float currentRotationAngle = transform.eulerAngles.y;
        float currentHeight = transform.position.y;
        float speed = Vector3.Magnitude(velocity) * 0.05f;
        // Damp the rotation around the y-axis
        currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime * speed);
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
