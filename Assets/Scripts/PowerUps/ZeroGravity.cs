using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeroGravity : PowerUp
{

    protected override void Init()
    {
        base.Init();
        Rigidbody playerRB = player.GetComponent<Rigidbody>();
        playerRB.useGravity = false;
    }
    private void OnDestroy()
    {
        if (player != null)
        {
            Rigidbody playerRB = player.GetComponent<Rigidbody>();
            playerRB.useGravity = true;
        }
    }
}
