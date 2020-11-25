using UnityEngine;

public class GunScript : MonoBehaviour
{
    public float damage = 10f;
    public float bulletSpeed = 1;
    public int clipSize = 40;
    public float lastfired;
    public float fireRate = 10;

    public Camera fpsCam;
    public GameObject bullet;
    public GameObject gunMuzzle;
    public ParticleSystem muzzleflash;
    public PlayerController gunOwner;
    public GameObject bulletCasing;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            if (Time.time - lastfired > 1 / fireRate)
            {
                lastfired = Time.time;
                Shoot();
            }
        }

    }

    void Shoot()
    {
        if(gunOwner.GetAmmoCount() > 0f)
        {
            GameObject tempBullet = Instantiate(bullet, gunMuzzle.transform.position, transform.rotation) as GameObject;
            Rigidbody tempRigidBodyBullet = tempBullet.GetComponent<Rigidbody>();
            tempRigidBodyBullet.AddForce(tempRigidBodyBullet.transform.forward * bulletSpeed);
            gunOwner.RemoveAmmo(1);
            GameObject tempCasing = Instantiate(bulletCasing, transform.position, transform.rotation) as GameObject;
            Rigidbody tempRigidBodyCasing = tempCasing.GetComponent<Rigidbody>();
            tempRigidBodyCasing.AddForce(tempRigidBodyCasing.transform.right * Random.Range(100, 300));
        }


    }
}
