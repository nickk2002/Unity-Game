using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UMP45 : Weapon
{
    public UMP45()
    {
        clipSize = 30;
        reloadTime = 2.0f;
        cooldownTime = 0.25f;
        isAutomatic = true;
        itemName = "UMP45";
        LoadImage();
    }
}
