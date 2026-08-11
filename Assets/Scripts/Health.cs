using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        // currentHealth = currentHealth - damageAmount
        currentHealth -= damageAmount;

        if (currentHealth <= 0) Die();
    }

    private void Die()
    {
        Debug.Log($"{gameObject.name} died");
        GameManager.Instance.OpenSceneLose();
    }
}