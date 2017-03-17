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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            if (!other.gameObject.GetComponent<SpeedPowerUp>())
            {
                //Add this power-up to player and activate
                SpeedPowerUp po = other.gameObject.AddComponent<SpeedPowerUp>();
                po.isTimed = isTimed;
                po.lifeTime = lifeTime;
                po.player = other.gameObject.GetComponent<Player>();
                po.speedBoost = speedBoost;
                po.Init();

                //Destroys the gameObject this script is attached to
                Destroy(gameObject);
            }
    }

    private void OnDestroy()
    {
        player.maxSpeed -= speedBoost;
    }
}
