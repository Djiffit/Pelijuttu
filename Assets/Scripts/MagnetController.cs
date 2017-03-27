using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetController : MonoBehaviour {

    public float radius = 10f;
    public float power = 0.5f;

    public bool isBlue = true;

    private GameObject player;
    private Collider collider;
     
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        collider = GetComponent<Collider>();
	}
	
	// Update is called once per frame
	void Update () {
        Magnet magnet = player.GetComponent<Magnet>();
        if (magnet != null)
        {
            if (magnet.isBlue && isBlue || !magnet.isBlue && !isBlue)
            {
                // Get the closest point of this object's rigid body to player position
                Vector3 closestPoint = collider.ClosestPointOnBounds(player.transform.position);
                Vector3 distanceVector = closestPoint - player.transform.position;
                float distance = Vector3.Magnitude(distanceVector);

                if (distance <= radius)
                {
                    // Distance needs to be inverted to make force stronger when closer
                    float invertedDistance = radius - distance;
                    Vector3 force = distanceVector.normalized * invertedDistance * power;
                    player.GetComponent<Rigidbody>().AddForce(force);
                }
            }
        }
	}
}
