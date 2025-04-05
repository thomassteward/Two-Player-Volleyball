using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementWithScrollbar : MonoBehaviour
{
    public Scrollbar velocityScrollbar; // The scrollbar controlling velocity
    public float maxSpeed = 5f;         // Maximum speed (positive and negative)
    public float accelerationRate = 1f; // How fast the velocity changes (acceleration rate)

    public float minX = -5f; // Minimum X position (left bound)
    public float maxX = 5f;  // Maximum X position (right bound)

    private Rigidbody2D rb;
    private float targetVelocity = 0f;
    private float currentVelocity = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (velocityScrollbar != null)
        {
            // Convert scrollbar value to velocity range, with 0.5f as 0 velocity
            targetVelocity = (velocityScrollbar.value - 0.5f) * maxSpeed * 2f; // -1 to 1 range
        }
    }

    void FixedUpdate()
    {
        // Gradually change the current velocity towards the target velocity
        currentVelocity = Mathf.MoveTowards(currentVelocity, targetVelocity, accelerationRate * Time.deltaTime);

        // Check if the object has reached its horizontal boundary
        if (transform.position.x <= minX && currentVelocity < 0f)
        {
            // If it's at or past the minX boundary and trying to move left, stop moving left
            currentVelocity = 0f;
        }
        else if (transform.position.x >= maxX && currentVelocity > 0f)
        {
            // If it's at or past the maxX boundary and trying to move right, stop moving right
            currentVelocity = 0f;
        }

        // Apply the velocity to the Rigidbody2D
        rb.linearVelocity = new Vector2(currentVelocity, rb.linearVelocity.y);

        // Constrain the object's position within the domain (minX, maxX)
        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }
}
