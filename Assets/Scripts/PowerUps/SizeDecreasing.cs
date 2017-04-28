using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeDecreasing : PowerUp
{
    public float speedIncreaseMultiplier;

    private Vector3 decrease = new Vector3(0.5F, 0.5F, 0.5F);
    private float speedIncrease;

    protected override void Init()
    {
        base.Init();

        speedIncrease = playerController.speed * decrease.magnitude * speedIncreaseMultiplier;
        playerController.speed += speedIncrease;

        if (player.GetComponent<SizeIncreasing>())
            Destroy(player.GetComponent<SizeIncreasing>());

        playerController.transform.localScale -= decrease;

    }
    protected override void OnDestroy()
    {
        base.OnDestroy();
        if (playerController != null)
        {
            playerController.transform.localScale += decrease;
            playerController.speed -= speedIncrease;
        }
    }
}
