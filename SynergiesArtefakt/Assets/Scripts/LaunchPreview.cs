using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchPreview : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private Vector2 startPoint; 


    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void SetStartPoint(Vector2 worldPoint)
    {
        startPoint = worldPoint;
        lineRenderer.SetPosition(0, startPoint);
    }

    public void SetEndPoint(Vector2 worldPoint)
    {
        Vector2 pointOffset = worldPoint - startPoint;
        Vector2 endPoint = (Vector2)transform.position + pointOffset;

        lineRenderer.SetPosition(1, endPoint); 
    }
}
