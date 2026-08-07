using System;
using System.Collections;
using UnityEngine;

public class EnemyShooter : Enemy
{
    public float shotInterval = 2f;

    public GameObject projectilePrefab;
    public float projectileSpeed = 5f;
    
    private void Start()
    {
        StartCoroutine(ShootProjectileCoro(shotInterval));
    }

    private IEnumerator ShootProjectileCoro(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime); // a way to pause the code
            ShootProjectile();
        }
    }

    private void ShootProjectile()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            Vector2 direction = (player.transform.position - transform.position).normalized;
            GameObject projectile = Instantiate(projectilePrefab,transform.position,Quaternion.identity);

            projectile.GetComponent<Rigidbody2D>().linearVelocity = direction * projectileSpeed;
        }
    }
}
