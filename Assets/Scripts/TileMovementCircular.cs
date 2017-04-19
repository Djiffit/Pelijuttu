using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMovementCircular : MonoBehaviour {

    public Transform pivot;
    public float RoundTripTime;
    public bool Clockwise;

    private Rigidbody rb;
    private float offset;
    private float angleTimeRatio;
    private float startTime;
    private float initialAngle;

    void Start () {
        rb = GetComponent<Rigidbody>();
        Vector3 offsetVector = gameObject.transform.position - pivot.position;
        offset = Vector3.Magnitude(offsetVector);
        initialAngle = Vector3.Angle(pivot.forward, offsetVector) + 180f;
        angleTimeRatio = 360f / RoundTripTime;
        startTime = Time.time;
    }

    void FixedUpdate()
    {
        // Calculate new angle
        float wantedAngle = (Time.time - startTime) * angleTimeRatio + initialAngle;
        if (!Clockwise)
            wantedAngle = 360 - wantedAngle;
        transform.rotation = Quaternion.Euler(transform.rotation.x, wantedAngle, transform.rotation.z);

        // Calculate new position
        Vector3 position = pivot.position;
        position -= transform.rotation * Vector3.forward * offset;
        transform.position = position;
    }
}
