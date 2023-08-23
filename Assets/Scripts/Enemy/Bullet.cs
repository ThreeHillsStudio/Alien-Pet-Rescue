using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int damageAmount;
    private void OnCollisionEnter(Collision collision)
    {
        IDamagable idamage = collision.transform.GetComponent<IDamagable>();

        if (idamage != null)
        {
            idamage.TakeDamage(damageAmount);
            Destroy(this.gameObject);
        }
    }
    
}
