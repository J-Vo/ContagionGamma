using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [HideInInspector]
    public Inventory playerInventory;
    public Text ammoCount;

   // public Text healthBar;

    // Start is called before the first frame update
    private void Start()
    {
        playerInventory = new Inventory();
        UpdateHUD();
    }

    public void UpdateHUD()
    {
        ammoCount.text = "Ammo: " + GetAmmoCount();

        //healthbar.text = "Heath:" + GetHealthAmount();
    }

    public void AddInventory(string item, float quantity)
    {
        playerInventory.AddInventory(item, quantity);
        UpdateHUD();
    }

    public float GetAmmoCount()
    {
        return playerInventory.GetItemCount("AmmoBox");
    }

    public void RemoveAmmo(float quantity)
    {
        playerInventory.RemoveInventory("AmmoBox", quantity);
        UpdateHUD();
    }
}
