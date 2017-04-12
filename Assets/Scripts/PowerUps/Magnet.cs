using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : PowerUp
{
    [HideInInspector]
    public bool isBlue = false;

    private Material playerMaterial;
    private Color playerColor;

    protected override void Init()
    {
        base.Init();
        playerMaterial = player.GetComponent<Renderer>().material;
        playerColor = playerMaterial.color;
        playerMaterial.color = Color.blue;
        isBlue = true;
    }

    void Update()
    {
        if (player != null)
        {
            if (Input.GetButtonDown("Change Magnet"))
            {
                ChangeMagnet();
            }
        }
    }

    void ChangeMagnet()
    {
        if (isBlue)
        {
            isBlue = false;
            playerMaterial.color = Color.red;
        }
        else
        {
            isBlue = true;
            playerMaterial.color = Color.blue;
        }
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        if (playerMaterial != null)
        {
            playerMaterial.color = playerColor;
        }
    }
}
