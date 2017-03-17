using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public bool isTimed = false;
    public float lifeTime = 5f;

    protected Player player;

    protected virtual void Init()
    {
        if (isTimed)
            Destroy(this, lifeTime);
    }
}