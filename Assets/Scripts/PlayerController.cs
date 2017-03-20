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

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        movement = Camera.main.transform.TransformDirection(movement).normalized;
        movement.y = 0;

        rigidbody.AddForce(movement * speed);
	}
}
