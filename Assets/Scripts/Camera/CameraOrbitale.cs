
using UnityEngine;

public class CameraOrbitale : MonoBehaviour
{
   [SerializeField] private Transform Weapon;
   [SerializeField] private float touchSpeed = 10; //touch sensitivity
   [SerializeField] private float orbitDamping = 10f;

   [SerializeField] private float minRotationX;

   [SerializeField] private float maxRotationX;

   private Vector3 localRot;
   private Vector2 initialTouchPosition;
   private Vector2 previousTouchPosition;

   private ZoomInWeapon zoomInWeapon;

   private void LateUpdate()
   {
      if (Input.touchCount > 0)
      {
         Touch touch = Input.GetTouch(0);

         if (touch.phase == TouchPhase.Began)
         {
            initialTouchPosition = touch.position;
            previousTouchPosition = touch.position;
         }
         else if (touch.phase == TouchPhase.Moved)
         {
            Vector2 touchDelta = touch.position - previousTouchPosition;

            localRot.x += touchDelta.x * touchSpeed;
            localRot.y -= touchDelta.y * touchSpeed;
            
            localRot.y = 0f;
            localRot.x = Mathf.Clamp(localRot.x, minRotationX, maxRotationX);
            
            Quaternion targetRotation = Quaternion.Euler(localRot.y, localRot.x, 0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * orbitDamping);

            previousTouchPosition = touch.position;
         }
      }
   }
}
