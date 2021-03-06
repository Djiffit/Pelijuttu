﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeroGravity : PowerUp
{

    protected override void Init()
    {
        base.Init();
        Rigidbody playerRB = playerController.GetComponent<Rigidbody>();
        playerRB.useGravity = false;
    }
    protected override void OnDestroy()
    {
        base.OnDestroy();
        if (playerController != null)
        {
            Rigidbody playerRB = playerController.GetComponent<Rigidbody>();
            playerRB.useGravity = true;
        }
    }
}
