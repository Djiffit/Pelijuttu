using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeDecreasing : PowerUp
{
    private Vector3 decrease = new Vector3(0.5F, 0.5F, 0.5F);

    protected override void Init()
    {
        base.Init();
        playerController.transform.localScale -= decrease;
    }
    protected override void OnDestroy()
    {
        base.OnDestroy();
        if (playerController != null)
        {
            playerController.transform.localScale += decrease;
        }
    }
}
