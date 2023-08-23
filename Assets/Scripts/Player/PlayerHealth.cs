using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerHealth : MonoBehaviour, IDamagable
{
    [SerializeField] public float health;
    [SerializeField] public float maxHealth;
    [SerializeField] public Slider healthBar;

    [SerializeField] private Vector3 gameOverUIScale;
    
    public Animator animator;

    public ParticleSystem dead;

    [SerializeField] private GameObject gameOverImg;
    
    private void Start()
    {
        maxHealth = health;
        
    }
    private void Update()
    {
        healthBar.value = Mathf.Clamp(health / maxHealth, 0, 1);
        animator.Play("Stand");
        
    }
    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;

        if (health <= 0)
        {
            dead.Play();
            Die();
            GameOverUI();
        }
    }

    public void GameOverUI()
    {
        gameOverImg.transform.DOScale(gameOverUIScale, 0.5f).SetDelay(1);
        
    }

    private void Die()
    {
        gameObject.SetActive(false);
        
    } 
}
