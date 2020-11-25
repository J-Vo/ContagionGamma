using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    //attributes
    public float health = 100;
    //attackDamage
    //attackRange
    //movement

    public GameObject myGameObject;
    public NavMeshAgent nav;
    public Transform goal;

    void Start()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
    }

    private void Update()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        if (agent.enabled)
        {
            agent.destination = goal.position;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Enemy collided");
        if (collision.gameObject.tag == "Projectile")
        {
            Debug.Log("Remove health");
            health -= 10;

            if (health <= 0){
                Death();
            }
            
        }
    }
    public void Death()
    {
        Debug.Log("Death");
        nav.enabled = false;
        Rigidbody gameObjectsRigidBody = myGameObject.AddComponent<Rigidbody>(); // Add the rigidbody.
       // BoxCollider gameObjectCollider = myGameObject.GetComponent<BoxCollider>();
       // gameObjectCollider.enabled = false;
        gameObjectsRigidBody.mass = 5;

    }
}
