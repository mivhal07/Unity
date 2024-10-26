using UnityEngine;

public class SlidingDoor : MonoBehaviour
{
    public Transform openPosition;
    public Transform closedPosition;
    public float speed = 2.0f;
    public float activationDistance = 3.0f;
    private Transform player;
    private Vector3 targetPosition;
    private bool isOpening = false;

    private void Start()
    {
        transform.position = closedPosition.position;
        targetPosition = closedPosition.position;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(player.position, transform.position);
        if (distanceToPlayer < activationDistance)
        {
            targetPosition = openPosition.position;
            isOpening = true;
        }
        else
        {
            targetPosition = closedPosition.position;
            isOpening = false;
        }
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }
}
