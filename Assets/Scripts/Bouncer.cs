using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : MonoBehaviour {
    public GameObject target;
    public float bounceForce;
    public float distance;

    private float startPositionY;
    private Rigidbody rb;
    private bool bouncing = false;

    private void Start()
    {
        startPositionY = target.transform.position.y;
        rb = target.GetComponent<Rigidbody>();
    }

    void LateUpdate () {
        if (target.transform.position.y <= startPositionY)
        {
            bouncing = false;
        }
        else if (target.transform.position.y - startPositionY >= distance)
        {
            rb.velocity = new Vector3(0f, 0f, 0f);
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!bouncing)
            {
                bouncing = true;
                rb.AddForce(0f, bounceForce, 0f);
            }
        }
    }
}
