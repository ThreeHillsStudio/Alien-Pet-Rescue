using System.Collections.Generic;
using UnityEngine;

public class DrawTrajectory : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField][Range(3, 30)] private int lineSeqmentCount = 20;
    [SerializeField] [Range(10, 100)] private int showProcentage = 50;
    [SerializeField] private int linePointCount;

    private List<Vector3> linePoints = new List <Vector3>();
    
    private void FixedUpdate()
    {
	    linePointCount = (int)(lineSeqmentCount * (showProcentage / 100f));
    }
    public static DrawTrajectory Instance;
    private void Awake()
    {
    	Instance = this;
    }
    public void UpdateTrajectory(Vector3 forceVector, Rigidbody rigidBody, Vector3 startingPoint)
    {
	    Vector3 velocity = (forceVector / rigidBody.mass) * Time.fixedDeltaTime;

	    float FlightDuration = ( velocity.y ) / Physics.gravity.y * 10;

	    float stepTime = FlightDuration / lineSeqmentCount;

	    linePoints.Clear();
        linePoints.Add(startingPoint);
        
        for (int i = 1; i < linePointCount; i++)
        {
	        float stepTimePassed = stepTime * i;

	        Vector3 movementVector = new Vector3(

		        velocity.x * stepTimePassed ,
		        (velocity.y * 1.4f * stepTimePassed - 0.5f * Physics.gravity.y * stepTimePassed * stepTimePassed) * 0.50f ,
			    velocity.y * stepTimePassed * 2
	        );

	        Vector3 NewPointnOnLine = -movementVector + startingPoint;
	        
	        linePoints.Add(NewPointnOnLine);
        }
        
        lineRenderer.positionCount = linePoints.Count;
        lineRenderer.SetPositions(linePoints.ToArray());
    }
    public void HideLine()
    {
	    lineRenderer.positionCount = 0;
    }
}


