using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    [SerializeField]
    private HealthController healthController;

    [SerializeField]
    private GameObject gameOver;

    [SerializeField]
    public AudioSource damageSource;

    [SerializeField]
    private AudioClip gameOverSound;

    private AudioSource _audioSource;

    private void Awake()
    {
        gameOver.SetActive(false);
    }

    void Die()
    {
        Debug.Log("Player Died!");
        gameOver.SetActive(true);
    }

    void Start()
    {
        currentHealth = maxHealth;
        healthController.changeHealth(currentHealth.ToString());

        _audioSource = GetComponent<AudioSource>();
    }

    public void TakeDamage(int damage)
    {
        // currentHealth = currentHealth - damageAmount
        currentHealth -= damage;

        healthController.changeHealth(currentHealth.ToString());

        damageSource.Play();

        if (currentHealth == 0)
        {
            GameManager.Instance.MuteAudioMaster();
            SoundAPI.Instance.PlayOneShotSound(gameObject, gameOverSound, 0.6f);
            Die();
        }
    } 
}