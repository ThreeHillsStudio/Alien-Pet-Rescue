
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public AnimalCollector AnimalCollector;
    
    private Vector3 spawnPos;
    private float newSpavnDuration = 1.0f;
    
    public GameObject spawnObject;
    public static Spawner Instance;
    public ZoomInWeapon zoomInWeapon;

    [SerializeField] private EnableTrajectory enableTrajectory;
    [SerializeField] private EnemyBullet[] enemyBullets;
    
    public Rigidbody rigidbody;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        
        spawnPos = transform.position;
    }
    void SpawnNewObject()
    {
        GameObject ball = Instantiate(spawnObject, spawnPos, Quaternion.identity);
        
        ball.GetComponent<ParticleSystemHit>().enemyBullets = enemyBullets;
        enableTrajectory.ChangeDragAndDropOfNewBall(ball);
            var rb = ball.GetComponent<Rigidbody>();
                
        rb.isKinematic = true;
        ball.GetComponent<DragAndShoot>().rigidbody = rb;
        var collectingSystem = ball.GetComponent<AnimalCollectingBall>();
        collectingSystem.AnimalCollector = AnimalCollector;
    }
    public void NewSpownRequest()
    {
        Invoke("SpawnNewObject", newSpavnDuration);
    }
}
