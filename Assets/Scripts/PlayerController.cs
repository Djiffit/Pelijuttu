using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Rigidbody rigidbody;
	public float speed = 5f;

	void Start () {
		rigidbody = GetComponent<Rigidbody> ();
    }

    void Update () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical) * speed * Time.deltaTime;

        // Calculate movement direction in relation to camera
        Vector3 movementDirection = Camera.main.transform.TransformDirection(movement);
        movementDirection.y = 0;
        movementDirection = movementDirection.normalized;

        rigidbody.AddForce(movement.magnitude * movementDirection);
	}
}
