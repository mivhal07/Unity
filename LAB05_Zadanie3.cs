using UnityEngine;
using System.Collections.Generic;

public class WaypointPlatform : MonoBehaviour
{
    public List<Vector3> waypoints = new List<Vector3>();
    public float speed = 2.0f;
    public bool activateOnPlayerEnter = true;

    private int currentWaypointIndex = 0;
    private bool isPlayerOnPlatform = false;
    private bool movingForward = true;
    private Transform playerTransform;
    private void Start()
    {
        for (int i = 0; i < waypoints.Count; i++)
        {
            waypoints[i] += transform.position;
        }

        if (waypoints.Count > 0)
        {
            transform.position = waypoints[0];
        }
    }

    private void Update()
    {
        if (activateOnPlayerEnter && !isPlayerOnPlatform)
        {
            return;
        }

        if (waypoints.Count == 0) return;
        Vector3 targetPosition = waypoints[currentWaypointIndex];
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
        {
            if (movingForward)
            {
                currentWaypointIndex++;
                if (currentWaypointIndex >= waypoints.Count)
                {
                    currentWaypointIndex = waypoints.Count - 2;
                    movingForward = false;
                }
            }
            else
            {
                currentWaypointIndex--;
                if (currentWaypointIndex < 0)
                {
                    currentWaypointIndex = 1;
                    movingForward = true;
                }
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
