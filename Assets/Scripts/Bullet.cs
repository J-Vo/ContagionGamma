using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject floor;

    public float damage;

    public void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy found");
            EnemyHealth eHealth = other.gameObject.GetComponent<EnemyHealth>();
            eHealth.AdjustCurrentHealth(damage);
        }
        Destroy(this.gameObject);
    }

    public float getDamage(){
        return this.damage;
    }
}
