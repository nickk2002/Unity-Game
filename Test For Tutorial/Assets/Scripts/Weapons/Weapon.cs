using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Weapon
{
    public int clipAmmunition = 0;
    public int totalAmmunition = 0;
    protected int clipSize = 0;
    protected int maxAmmunition = 0;
    protected float reloadTime = 0.0f;
    protected float cooldownTime = 0.0f;
    protected bool isAutomatic = false;
    
    public string itemName, itemDescription;
    public Sprite itemSprite,bulletSprite;
    public GameObject Prefab;
    public Vector3 position, rotation;
    public int ClipAmmunition{ get{ return clipAmmunition; } set{ clipAmmunition = value;} }
    public int TotalAmmunition { get { return totalAmmunition; } set { totalAmmunition = value; } }
    public int ClipSize { get { return clipSize; } }
    public int MaxAmmunition { get { return maxAmmunition; } }
    public float ReloadTime { get { return reloadTime; } }
    public float CooldownTime { get { return cooldownTime; } }
    public bool IsAutomatic { get { return isAutomatic; } }
    public void AddAmmuntion(int amount)
    {
        if (totalAmmunition + amount <= totalAmmunition)
            totalAmmunition += amount;
    }
    public void LoadClip()
    {
        int remainder = clipSize - clipAmmunition;
        int ammunitiontoLoad = Mathf.Min(totalAmmunition, remainder);
        clipAmmunition += ammunitiontoLoad;
        totalAmmunition -= ammunitiontoLoad;
    }
    public void LoadImage()
    {
        if (itemSprite == null)
        {
            Prefab = Resources.Load<GameObject>("Prefabs/Weapons/" + itemName);
            itemSprite = Resources.Load<Sprite>("Images/" + itemName);
            bulletSprite = Resources.Load<Sprite>("Images/" + itemName + "bullets");
            if (itemSprite != null && bulletSprite != null && Prefab != null)
                Debug.Log(itemName + "Loaded succesfully Te iubesc iepuras");
            else
                Debug.LogWarning("Now you fucked up!");
        }
    }
}
