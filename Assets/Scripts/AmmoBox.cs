using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    public int ammoCount = 10;

    public void OnTriggerEnter(Collider other)
    {
        PlayerController pc = other.GetComponent<PlayerController>();
        if(pc != null) 
        {
            pc.AddInventory("AmmoBox", ammoCount);
            Destroy(this.gameObject);
        }
    }
}
