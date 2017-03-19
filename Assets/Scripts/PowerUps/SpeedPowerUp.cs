using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : PowerUp {
    public float speedBoost = 20f;

    protected override void Init()
    {
        base.Init();
        player.maxSpeed += speedBoost;
    }

    private void OnDestroy()
    {
        if (player != null)
        {
            player.maxSpeed -= speedBoost;
        }
    }
}
