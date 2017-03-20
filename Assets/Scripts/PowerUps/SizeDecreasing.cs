using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeDecreasing : PowerUp
{
    private Vector3 decrease = new Vector3(0.5F, 0.5F, 0.5F);

    protected override void Init()
    {
        base.Init();
        player.transform.localScale -= decrease;
    }
    private void OnDestroy()
    {
        if (player != null)
        {
            player.transform.localScale += decrease;
        }
    }
}
