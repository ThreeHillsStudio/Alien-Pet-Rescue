using UnityEngine;

public class DottedLineRenderer : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public float dotSpacing = 0.1f;
    public float dotSize = 0.1f;
    public Color dotColor = Color.white;
    
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = dotSize;
        lineRenderer.endWidth = dotSize;
        
        SetDottedLine();
    }
    
    void SetDottedLine()
    {
        float lineLength = 0f;
        
        for (int i = 1; i < lineRenderer.positionCount; i++)
        {
            Vector3 previousPosition = lineRenderer.GetPosition(i - 1);
            Vector3 currentPosition = lineRenderer.GetPosition(i);
            lineLength += Vector3.Distance(previousPosition, currentPosition);
        }
        
        int dotCount = Mathf.CeilToInt(lineLength / dotSpacing);
        
        lineRenderer.positionCount = dotCount;
        
        for (int i = 0; i < dotCount; i++)
        {
            float normalizedDistance = i / (float)(dotCount - 1);
            lineRenderer.SetPosition(i, lineRenderer.GetPosition(0) + normalizedDistance * lineLength * transform.forward);
        }
        
        lineRenderer.startColor = dotColor;
        lineRenderer.endColor = dotColor;
    }
}