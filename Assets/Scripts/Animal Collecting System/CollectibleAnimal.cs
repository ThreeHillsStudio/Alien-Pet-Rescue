using UnityEngine;
using UnityEngine.UI;

public class CollectibleAnimal : MonoBehaviour
{
    [SerializeField] private ParticleSystem explosion;
    [SerializeField] private Image image;
    public ParticleSystem ringParticle;
    
    public Animator anim;
    private void Start()
    {
        image.enabled = false;
    }
    public void OnCollisionWithBall()
    {
        image.enabled = true;
        ActivateParticleSystem();
        anim.Play("Happy");
    }
    private void ActivateParticleSystem()
    {
        if (explosion != null)
        {
            explosion.transform.position = transform.position;
            explosion.Play();
        }
    }
}