using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon {
    public Pistol()
    {
        clipSize = 12;
        maxAmmunition = 60;
        reloadTime = 2.0f;
        cooldownTime = 0.25f;
        isAutomatic = false;
        itemName = "Pistol";
        LoadImage();
    }
}
