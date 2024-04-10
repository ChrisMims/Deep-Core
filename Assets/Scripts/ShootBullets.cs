using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class ShootBullets : MonoBehaviour
{
    public int currentRounds;
    public GameObject bullet;
    public float bulletVelocity;
    [MinValue(0.1f)]
    public float fireRate;
    void Update()
    {
        if (Input.GetMouseButtonUp(0)) { StartCoroutine(AutomaticShoot(currentRounds, fireRate)); }

    }

    IEnumerator AutomaticShoot(int bulletAmount, float delayBetweenShots)
    {
        for (int i = 0; i < currentRounds; i++)
        {
            Shoot();
            yield return new WaitForSeconds(delayBetweenShots);
        }
    }
    private void Shoot()
    {
            GameObject spawnedBullet = Instantiate(bullet, this.transform.position, this.transform.rotation);
            spawnedBullet.layer = LayerMask.NameToLayer("BulletLayer");
            Rigidbody2D bulletRigidbody = spawnedBullet.GetComponent<Rigidbody2D>();
            bulletRigidbody.velocity = this.transform.up * bulletVelocity;
    }
}
