using UnityEngine;

public class MoveCubeSquare : MonoBehaviour
{
    public float speed = 2.0f;
    private Vector3[] corners;
    private int currentCorner = 0;
    private float tolerance = 0.1f;

    void Start()
    {
        Vector3 startPosition = transform.position;
        corners = new Vector3[4];
        corners[0] = startPosition;
        corners[1] = startPosition + new Vector3(10, 0, 0);
        corners[2] = corners[1] + new Vector3(0, 0, 10);
        corners[3] = corners[2] - new Vector3(10, 0, 0);
        transform.LookAt(corners[1]);
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, corners[currentCorner], speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, corners[currentCorner]) < tolerance)
        {
            currentCorner = (currentCorner + 1) % corners.Length;
            Vector3 nextCorner = corners[currentCorner];
            transform.LookAt(nextCorner);
        }
    }
}
