using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMovement : MonoBehaviour {

    private Rigidbody rb;
    public Transform StartPoint;
    public Transform EndPoint;
    public float RoundTravelTime;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 currentPosition = Vector3.Lerp(StartPoint.position, EndPoint.position, Mathf.Cos(Time.time / RoundTravelTime * Mathf.PI * 2) * -0.5f + 0.5f);
        rb.MovePosition(currentPosition);
    }
}