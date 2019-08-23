using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject floor;

    void OnCollisionEnter(Collision collision)
    {
        //only destroy when it hits the ground
        if(collision.gameObject.name == "Floor")
        {
            Destroy(this.gameObject, 2.0f);
        }
    }
}
