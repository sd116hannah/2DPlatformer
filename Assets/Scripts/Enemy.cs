using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damageToPlayer = 10;
    public bool destroyOnCollision = false;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            DealDamageToPlayer(collider);
        }

        if (destroyOnCollision) Destroy(gameObject);
    }

    private void DealDamageToPlayer(Collider2D playerCollider)
    {
        Health playerHealth = playerCollider.GetComponent<Health>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damageToPlayer);
        }
    }
}
