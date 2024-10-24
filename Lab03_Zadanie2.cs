using UnityEngine;

public class MoveCube : MonoBehaviour
{
    public float speed = 4.0f;
    private float startX;
    private float targetX;
    private bool movingRight = true;

    void Start()
    {
        startX = transform.position.x;
        targetX = startX + 10.0f;
    }

    void Update()
    {
        if (movingRight)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;

            if (transform.position.x >= targetX)
            {
                movingRight = false;
            }
        }
        else
        {
            transform.position -= Vector3.right * speed * Time.deltaTime;

            if (transform.position.x <= startX)
            {
                movingRight = true;
            }
        }
    }
}
