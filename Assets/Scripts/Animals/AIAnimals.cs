using UnityEngine;
using UnityEngine.AI;

public class AIAnimals : MonoBehaviour
{
    private NavMeshAgent agent;
    public float radius;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        if (!agent.hasPath)
        {
            agent.SetDestination( EnemyMoving.Instance.GetRendomPoint());
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}