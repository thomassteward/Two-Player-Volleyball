using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    public Transform target;               // The object to follow (e.g., ball)
    public float followSpeed = 1f;         // How fast the camera catches up when following
    public float catchUpSpeed = 2.5f;      // How fast it catches up when the ball is still
    public float stillTimeThreshold = 1f;  // Time the ball must be still before camera centers
    public float movementThreshold = 0.05f;// How much the ball has to move to count as "moving"
    public Vector3 offset;                 // Optional offset

    private float stillTimer = 0f;
    private Vector3 lastTargetPos;

    void Start()
    {
        if (target != null)
            lastTargetPos = target.position;
    }

    void LateUpdate()
    {
        if (target == null) return;

        float distanceMoved = Vector3.Distance(target.position, lastTargetPos);

        // Check if the target has moved enough to reset stillTimer
        if (distanceMoved > movementThreshold)
        {
            stillTimer = 0f;
        }
        else
        {
            stillTimer += Time.deltaTime;
        }

        // Determine how fast to follow
        float speed = (stillTimer >= stillTimeThreshold) ? catchUpSpeed : followSpeed;

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, speed * Time.deltaTime);
        smoothedPosition.z = transform.position.z; // Lock Z for 2D
        transform.position = smoothedPosition;

        lastTargetPos = target.position;
    }
}
