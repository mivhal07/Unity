Script 1: PlayerMovement

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }
}


Script 2: MovingPlatform

using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public float speed = 2.0f;

    private bool isPlayerOnPlatform = false;
    private bool movingToEnd = true;
    private Vector3 targetPosition;
    private Transform playerTransform;
    private void Start()
    {
        transform.position = startPoint.position;
        targetPosition = endPoint.position;
    }

    private void Update()
    {
        if (isPlayerOnPlatform)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                targetPosition = movingToEnd ? startPoint.position : endPoint.position;
                movingToEnd = !movingToEnd;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerOnPlatform = true;
            playerTransform = other.transform;
            playerTransform.SetParent(transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerOnPlatform = false;
            playerTransform.SetParent(null);
            playerTransform = null;
        }
    }
}
