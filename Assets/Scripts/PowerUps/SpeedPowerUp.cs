using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : PowerUp {
    public float speedBoost = 20f;

    protected override void Init()
    {
        base.Init();
        playerController.speed += speedBoost;
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        if (playerController != null)
        {
            playerController.speed -= speedBoost;
        }
    }
}
