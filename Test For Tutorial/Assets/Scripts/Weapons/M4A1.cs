using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M4A1 : Weapon
{
    public M4A1()
    {
        clipSize = 30;
        reloadTime = 2.0f;
        cooldownTime = 0.25f;
        isAutomatic = true;
        itemName = "M4A1";
        LoadImage();
    }
}
