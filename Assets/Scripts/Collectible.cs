using UnityEngine;

public class Collectible : MonoBehaviour
{
    public AudioClip collectibleSound;
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            SoundAPI.Instance.PlayOneShotSound(collider.gameObject, collectibleSound, 1.0f);
            GameManager.Instance.AddScore();
            Destroy(gameObject);
        }
    }
}