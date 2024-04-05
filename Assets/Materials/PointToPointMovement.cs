using UnityEngine;

public class PointToPointMovement : MonoBehaviour
{
    public Vector3[] points; 
    public float speed = 5f; 
    private int currentIndex = 0;
    private bool forward = true; 
    void Update()
    {
        MoveBetweenPoints();
    }
    void MoveBetweenPoints()
    {
        transform.position = Vector3.MoveTowards(transform.position, points[currentIndex], speed * Time.deltaTime);
        
        if (Vector3.Distance(transform.position, points[currentIndex]) < 0.1f)
        {
            if (forward)
            {
                if (currentIndex < points.Length - 1)
                {
                    currentIndex++;
                }
                else
                {
                    forward = false;
                }
            }
            else
            {
                if (currentIndex > 0)
                {
                    currentIndex--;
                }
                else
                {
                    forward = true;
                }
            }
        }
    }
}