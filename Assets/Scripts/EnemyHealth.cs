using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float curHealth = 100;

    public float healthBarLength;

    // Use this for initialization
    public void AdjustCurrentHealth(float adj)
    {
        this.curHealth += adj;

        if (this.curHealth <= 0)
        { 
            Enemy en = GetComponent<Enemy>();
            en.Death();
        }
    }
}
