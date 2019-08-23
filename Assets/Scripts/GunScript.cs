using UnityEngine;

public class GunScript : MonoBehaviour
{
    public float damage = 10f;
    public float bulletSpeed = 1;
    public int clipSize = 40;


    public Camera fpsCam;
    public GameObject bullet;
    public ParticleSystem muzzleflash;
    public PlayerController gunOwner;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

    }

    void Shoot()
    {
        if(gunOwner.GetAmmoCount() > 0f)
        {
            GameObject tempBullet = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
            Rigidbody tempRigidBodyBullet = tempBullet.GetComponent<Rigidbody>();
            tempRigidBodyBullet.AddForce(tempRigidBodyBullet.transform.forward * bulletSpeed);

            gunOwner.RemoveAmmo(1);
        }


    }
}
