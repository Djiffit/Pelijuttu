using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

    public float ySpeed;
    public float xSpeed;
    public float zSpeed;
    public bool globalSpace;

	void Update () {
        Vector3 rotation = new Vector3(xSpeed, ySpeed, zSpeed) * Time.deltaTime;
        transform.Rotate(rotation.x, rotation.y, rotation.z, Space.World);
	}
}
