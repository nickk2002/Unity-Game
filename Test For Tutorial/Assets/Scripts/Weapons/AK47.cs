using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK47 : Weapon {
    public AK47()
    {
        clipSize = 30;
        reloadTime = 2.0f;
        cooldownTime = 0.25f;
        isAutomatic = false;
        itemName = "AK47";
        LoadImage();
    }
}
