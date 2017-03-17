using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	private Rigidbody rigidbody;
	public float maxSpeed = 20f;
	public float turnSpeed = 180f;

	void Start () {
		rigidbody = GetComponent<Rigidbody> ();
	}

	void Update () {
		
		Vector3 movement = transform.forward  * Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime;
		rigidbody.MovePosition (rigidbody.position + movement);

		float turn = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;

		Quaternion turnRotation = Quaternion.Euler (0f, turn, 0f);
		rigidbody.MoveRotation (turnRotation * rigidbody.rotation);
		
	}
}
