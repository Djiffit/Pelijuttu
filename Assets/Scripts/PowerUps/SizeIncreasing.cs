using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeIncreasing : PowerUp
{
    private Vector3 increase = new Vector3(1.0F,1.0F,1.0F);

    protected override void Init()
    {
        base.Init();
        player.transform.localScale += increase;
    }
    private void OnDestroy()
    {
        if (player != null)
        {
            player.transform.localScale -= increase;
        }
    }
}
