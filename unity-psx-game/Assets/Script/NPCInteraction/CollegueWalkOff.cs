using UnityEngine;

public class CollegueWalkOff : MonoBehaviour
{
    [SerializeField] private GameObject WaypointList;
    [SerializeField] private Animator animator;
    [SerializeField] private float moveSpeed = 2f;

    private DialogueTrigger dialogueTrigger;
    private Transform[] waypoints;
    private int currentWaypointIndex = 0;
    private bool isMoving = false;

    private void Start()
    {
        dialogueTrigger = GetComponent<DialogueTrigger>();

        // R�cup�rer tous les enfants de WaypointList comme waypoints
        int childCount = WaypointList.transform.childCount;
        waypoints = new Transform[childCount];

        for (int i = 0; i < childCount; i++)
        {
            waypoints[i] = WaypointList.transform.GetChild(i);
        }
    }

    private void Update()
    {
        if (dialogueTrigger.isFinished && !isMoving)
        {
            StartMoving();
        }
        if (dialogueTrigger.isFinished && isMoving)
        {
            MoveTowardsWaypoint();
        }
    }

    private void StartMoving()
    {
        gameObject.layer = 7;
        animator.SetBool("isWalking", true);
        isMoving = true;
        currentWaypointIndex = 0;
    }

    private void MoveTowardsWaypoint()
    {
        if (currentWaypointIndex >= waypoints.Length)
        {
            // Arr�t si tous les waypoints sont atteints
            isMoving = false;
            return;
        }

        Transform targetWaypoint = waypoints[currentWaypointIndex];
        Vector3 direction = (targetWaypoint.position - transform.position).normalized;
        float step = moveSpeed * Time.deltaTime;

        // Regarder dans la direction du mouvement
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, step * 2);
        }

        // D�placer le NPC vers le waypoint
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, step);

        // Passer au waypoint suivant si le courant est atteint
        if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            currentWaypointIndex++;
        }
    }
}
