using UnityEngine;

public class ParticleSystemHit : MonoBehaviour
{
    [SerializeField] public ParticleSystem explosion;
    [SerializeField] public EnemyBullet[] enemyBullets;
    
    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Test"))
        {
            explosion.Play();

            Destroy(gameObject, 0.2f);
        }
    }
}