using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medkit : MonoBehaviour
{
    public float healthCount;

    public void OnTriggerEnter(Collider other)
    {
        PlayerController pc = other.GetComponent<PlayerController>();
        if (pc != null)
        {
            pc.AddInventory("Medkit", healthCount);
            pc.ConsumeMedkit(healthCount);
            Destroy(this.gameObject);
        }
    }

}
