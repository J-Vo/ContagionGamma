using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float curHealth = 100;
    public GameObject player;
    public bool isDead = false;

    public void adjustHealth(float adjustment)
    {
        curHealth += adjustment;

        player.GetComponent<PlayerController>().UpdateHUD();

        player.GetComponentInChildren<ParticleSystem>().Play();

        if (curHealth <= 0)
        {
            isDead = true;
        }
    }

    public float getHealth()
    {
        return curHealth;
    }
}
