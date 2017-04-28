using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeIncreasing : PowerUp
{
    public float speedDecreaseMultiplier = 0.25f;

    private Vector3 increase = new Vector3(1.0F,1.0F,1.0F);
    private float bigMass = 2f;
    private float oldMass;
    private float speedDecrease;
    private Rigidbody playerBody;

    protected override void Init()
    {
        base.Init();

        speedDecrease = playerController.speed * increase.magnitude * speedDecreaseMultiplier;
        playerController.speed -= speedDecrease;

        playerController.transform.localScale += increase;
        playerBody = player.GetComponent<Rigidbody>();
        oldMass = playerBody.mass;
        playerBody.mass = bigMass;
        
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        if (playerController != null)
        {
            playerBody.mass = oldMass;
            playerController.transform.localScale -= increase;
            playerController.speed += speedDecrease;
        }
    }
}
