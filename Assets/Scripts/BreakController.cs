using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakController : MonoBehaviour {

    public float BreakingPoint;

    private TriangleExplosion expl;

    void Start () {
        expl = GetComponent<TriangleExplosion>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        float collisionStrength = Vector3.Magnitude(collision.impulse);
        if (collisionStrength >= BreakingPoint)
            StartCoroutine(expl.SplitMesh(true));
    }
}
