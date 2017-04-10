using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : MonoBehaviour {
    public GameObject target;
    public float bounceSpeed;
    public float returnSpeed;
    public float distance;

    private float startPositionY;
    private bool active;
    private bool goingUp;
    private Rigidbody rb;

    private void Start()
    {
        goingUp = true;
        startPositionY = target.transform.position.y;
        rb = target.GetComponent<Rigidbody>();
    }

	void LateUpdate () {
		if (active)
        {
            Vector3 position = target.transform.position;
            if (goingUp)
            {
                // Move up
                position.y += bounceSpeed * Time.deltaTime;

                // Check if full distance traveled
                if (position.y - startPositionY >= distance)
                {
                    goingUp = false;
                }
            }
            else
            {
                // Move down
                position.y -= returnSpeed * Time.deltaTime;

                // Check if returned
                if (position.y <= startPositionY)
                {
                    position.y = startPositionY;
                    goingUp = true;
                    active = false;
                }
            }

            // Set new position
            rb.MovePosition(position);
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            active = true;
        }
    }
}
