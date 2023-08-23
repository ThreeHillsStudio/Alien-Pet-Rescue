using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using Vector3 = UnityEngine.Vector3;

public class TransformationWalkAnimal : MonoBehaviour
{
    [SerializeField] private ParticleSystem explosion;
    [SerializeField] private Image image;
    public Animator anim;
    public Transform childTransform;
    public NavMeshAgent agent;
    public ParticleSystem runParticle;

    public Transform[] animals;     
    public Transform[] targetObjects; 

    private Vector3[] initialPositions; 
    private void Start()
    {
        image.enabled = false;
        // if (childTransform == null)
        // {
        //     childTransform = transform.GetChild(0);
        // }
        //
        // initialPositions = new Vector3[animals.Length];
        // for (int i = 0; i < animals.Length; i++)
        // {
        //     initialPositions[i] = animals[i].position;
        // }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            runParticle.Stop();
            
            image.enabled = true;
            agent.enabled = false;
            
            ActivateParticleSystem();
            
            anim.Play("Happy");
            
            MoveAnimalsToTarget();
        }
    }
    private void ActivateParticleSystem()
    {
        if (explosion != null)
        {
            explosion.transform.position = transform.position;
            explosion.Play();
        }
    }
    private void MoveAnimalsToTarget()
    {
        if (animals == null || targetObjects == null || animals.Length != targetObjects.Length)
        {
            return;
        }

        for (int i = 0; i < animals.Length; i++)
        {
            Transform animal = animals[i];
            Transform targetObject = targetObjects[i];

            if (animal == null || targetObject == null)
            {
                continue;
            }
            animal.position = targetObject.position;
            
            animal.rotation = targetObject.rotation;
        }
    }
}
