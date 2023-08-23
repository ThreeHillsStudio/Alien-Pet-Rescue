using UnityEngine;

public class EnableTrajectory : MonoBehaviour
{ 
    [SerializeField] private DrawTrajectory drawTrajectory;
    [SerializeField] private DragAndShoot dragAndShoot;
    [SerializeField] private ZoomInWeapon zoomInWeapon;
    
    private void Update()
    {
         Debug.Log(dragAndShoot.canShoot);
        if (zoomInWeapon._zoomInToggle)
        {
            
            drawTrajectory.enabled = false;
            DrawTrajectory.Instance.HideLine();
            dragAndShoot.canShoot = false;
        }
        else
        {
            drawTrajectory.enabled = true;
            dragAndShoot.canShoot = true; 
            dragAndShoot.enabled = true;
        }
    }
    public void ChangeDragAndDropOfNewBall(GameObject newBall)
    {
        dragAndShoot = newBall.GetComponent<DragAndShoot>();
    }
}
