using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
   private NavMeshAgent agent;
   
   public float radius;
   public ZoomInWeapon zoomInWeapon;
   
   private void Start()
   {
      agent = GetComponent<NavMeshAgent>();
      
      agent.updateRotation = false;
      
      agent.isStopped = false;
   }
   private void Update()
   {
      if (!zoomInWeapon._zoomInToggle)
      {
         agent.updateRotation = false;
         
         agent.speed = 0;
         return;
      }
      else
      {
         agent.speed = 3.5f;
         agent.updateRotation = true;
         agent.isStopped = false;
      }
   
      
      if (!agent.hasPath && zoomInWeapon._zoomInToggle)
      {
         var newPoint = EnemyMoving.Instance.GetRendomPoint();
        agent.SetDestination(newPoint);
        RotateTowards(newPoint);
      }
   }
   private void OnDrawGizmos()
   {
      Gizmos.DrawWireSphere(transform.position, radius);
   }
   
   private void RotateTowards (Vector3 target) {
      Vector3 direction = (target - transform.position).normalized;
      Quaternion lookRotation = Quaternion.LookRotation(direction);
      transform.rotation = lookRotation;
   }
}
