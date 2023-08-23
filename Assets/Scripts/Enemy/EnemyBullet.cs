using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;
public class EnemyBullet : MonoBehaviour
{
    public GameObject enemyBullet;
    public Transform spawnPoint;
    public float bulletForce = 20f;
    public float rotationSpeed = 10f;
    public float rotationSmoothness = 5f;
    
    private int shootCount = 1;
    private bool isShooting;
    private GameObject ball;
    float timeForAnimation = 0.5f;
    
    [SerializeField]private float bulletTime;
    [SerializeField] private float timer = 5f;
    [SerializeField]private PlayerHealth playerHealth;
    [SerializeField]private bool canShoot;
    [SerializeField] private ZoomInWeapon zoomInWeapon;
    [SerializeField] private Animator stickmanAnimator;
    
    private void Update()
    {
        if (ZoomInWeapon.instance._zoomInToggle == false)
        {
            ShootAtPlayer(shootCount % 4 == 0);
        }
    }

    void ShootAtPlayer(bool shootHim)
    {
        float rotationInput = Input.GetAxis("Horizontal");
        float targetRotation2 = rotationInput * rotationSpeed;

        Quaternion targetRotationQuaternion = Quaternion.Euler(0f, targetRotation2, 0f);

        if (true)
        {
            bulletTime -= Time.deltaTime;

            if (bulletTime > 0) { return; }

            StartCoroutine(ShootAnimation());
            zoomInWeapon.isShooting = true;
            shootCount++;
            bulletTime = timer;
            zoomInWeapon.isTimerFinished = true;
            
            Vector3 targetDirection = playerHealth.transform.position - spawnPoint.position;
            RaycastHit hit;

           
            if (Physics.Raycast(spawnPoint.position, targetDirection, out hit) && hit.collider.CompareTag("Ball"))
            {
                return;
            }

            GameObject bulletObj = Instantiate(enemyBullet, spawnPoint.transform.position, quaternion.identity);
            Rigidbody bulletRig = bulletObj.GetComponent<Rigidbody>();
            bulletRig.velocity = targetDirection.normalized * bulletForce;

            if (!shootHim)
                bulletRig.velocity +=
                    Vector3.left * (float)math.pow(-1, (Random.Range(0, 1) + 1)) * 5 * (float)Random.value; 
                bulletRig.angularVelocity = Vector3.zero;
        }
    }
    IEnumerator ShootAnimation()
    {
        yield return null;
        stickmanAnimator.Play("Shoot");
        yield return new WaitForSeconds(timeForAnimation);
        
        zoomInWeapon.isShooting = false;
        zoomInWeapon.isTimerFinished = false;
    }
}