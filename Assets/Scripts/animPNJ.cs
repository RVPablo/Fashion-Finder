using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    public Transform[] waypoints;
    public float moveSpeed = 2f;
    public Animator animator;

    private int waypointIndex = 0;
    private Transform targetWaypoint;

    void Start()
    {
        if (waypoints.Length > 0)
        {
            targetWaypoint = waypoints[waypointIndex];
        }
    }

    void Update()
    {
        if (targetWaypoint != null)
        {
            MoveTowardsWaypoint();
        }
    }

    void MoveTowardsWaypoint()
    {
        Vector3 direction = targetWaypoint.position - transform.position;
        float distance = direction.magnitude;

        if (distance < 0.1f)
        {
            waypointIndex = (waypointIndex + 1) % waypoints.Length;
            targetWaypoint = waypoints[waypointIndex];
        }
        else
        {
            Vector3 move = direction.normalized * moveSpeed * Time.deltaTime;
            transform.position += move;
            UpdateAnimation(direction);
        }
    }

    void UpdateAnimation(Vector3 direction)
    {
        direction.Normalize();

        animator.SetFloat("Speed", direction.magnitude);

        animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Vertical", direction.y);
    }
}
