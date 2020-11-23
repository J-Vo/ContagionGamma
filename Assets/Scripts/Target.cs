
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            TakeDamage(200f);
        }


    }
  public void TakeDamage(float amount)
    {

        health -= amount;

        if(health <= 0f)
        {

        }
    }

}
