using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [HideInInspector]
    public Inventory playerInventory;
    public Text ammoCount;

    public float health;

    public Slider slider;
    
    // Start is called before the first frame update
    private void Start()
    {
        playerInventory = new Inventory();
        UpdateHUD();
    }

    public void UpdateHUD()
    {
        ammoCount.text = "Ammo: " + GetAmmoCount();

        slider.value = GetHealthStatus();

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

    public void ConsumeMedkit(float quantity)
    {
        float difference;

        if (quantity + health > slider.maxValue)
        {
            difference = (quantity + health) - slider.maxValue;

            difference = quantity - difference;

            health += difference;
        }
        else{
            health += quantity;
        }

        playerInventory.RemoveInventory("Medkit", quantity);

        UpdateHUD();
    }
    public float GetHealthStatus()
    {
        return  health;
    }
}