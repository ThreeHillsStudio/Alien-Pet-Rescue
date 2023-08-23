
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemyMoving : MonoBehaviour
{
   private bool canMove;
   
   public static EnemyMoving Instance;
   public float range;

   private void Awake()
   {
      Instance = this;
   }
   bool RandomPoint(Vector3 center, float range, out Vector3 result)
   {
      for (int i = 0; i < 30; i++)
      {
         Vector3 randomPoint = center + Random.insideUnitSphere * range;
         NavMeshHit hit;
         if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
         {
            result = hit.position;
            return true;
         }
      }
      result = Vector3.zero;
      return false;
   }

   public Vector3 GetRendomPoint(Transform point = null, float radius = 0)
   {
      Vector3 _point;

      if (RandomPoint(point == null?transform.position : point.position, radius == 0? range : radius, out _point))
      {
         Debug.DrawRay(_point, Vector3.up, Color.black, 1);

         return _point;
      }
      return point == null ? Vector3.zero : point.position;
   }

   private void OnDrawGizmos()
   {
      Gizmos.DrawWireSphere(transform.position, range);
   }
}
