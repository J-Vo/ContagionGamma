using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        //only destroy when it hits the ground
        if(collision.gameObject.name == "Floor")
        {
            Destroy(this.gameObject, 2.0f);
        }
    }
}
