using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public NavMeshAgent nav;
    public Transform goal;

    //attributes
    public float health = 100;
    public bool alive = true;
    

    //attack
    public float attackDamage = -10;
    public float lastAtttackTime;
    public float attackRate = 3;
    public float attackRange = 3f;
    public float curDistance;



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

        curDistance = Vector3.Distance(this.transform.position, goal.position);

        if (curDistance < attackRange && Time.time - lastAtttackTime > attackRate && alive)
        {
            lastAtttackTime = Time.time;
            Attack();
        }

    }

    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Enemy collided");
        if (collision.gameObject.tag == "Projectile")
        {
            Debug.Log("Remove health");
            health -= 10;

            if (health <= 0 && alive){
                Death();
            }
            
        }
    }
    public void Death()
    {
        Debug.Log("Death");
        nav.enabled = false;
        Rigidbody gameObjectsRigidBody = this.gameObject.AddComponent<Rigidbody>(); // Add the rigidbody.
        alive = false;
       // BoxCollider gameObjectCollider = myGameObject.GetComponent<BoxCollider>();
       // gameObjectCollider.enabled = false;

    }
    public void Attack()
    {
       PlayerHealth health = player.GetComponent<PlayerHealth>();

        health.adjustHealth(attackDamage);
    }
}
