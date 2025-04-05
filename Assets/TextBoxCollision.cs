using UnityEngine;
using TMPro; // Make sure you include this namespace

public class TextBoxCollision : MonoBehaviour
{
    // References to the TextMeshPro UI text boxes that will display the values
    public TextMeshProUGUI textBox1;  // The first TextMeshPro text box (variable 1)
    public TextMeshProUGUI textBox2;  // The second TextMeshPro text box (variable 2)

    private int value1 = 0;  // Variable for textBox1 (this starts as 0)
    private int value2 = 0;  // Variable for textBox2 (this starts as 0)

    // Teleport destinations
    public Vector3 playerTeleportLocation = new Vector3(5, 0, 0);  // Example position for Player collision
    public Vector3 finishTeleportLocation = new Vector3(-5, 0, 0);  // Example position for Finish collision

    private Rigidbody2D rb;  // Reference to the Rigidbody2D component

    void Start()
    {
        // Make sure the text boxes display the initial values
        UpdateTextBoxes();

        // Get the Rigidbody2D component attached to this object
        rb = GetComponent<Rigidbody2D>();
    }

    // This function will be called on collision with the "Player" or "Finish" tagged objects
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check for "Player" tag
        if (collision.gameObject.CompareTag("Player"))
        {
            value1++;  // Add 1 to value1 (Text Box 1)
            UpdateTextBoxes();

            // Teleport to Player destination and reset velocity to 0
            transform.position = playerTeleportLocation;
            ResetVelocity();
        }

        // Check for "Finish" tag
        else if (collision.gameObject.CompareTag("Finish"))
        {
            value2++;  // Add 1 to value2 (Text Box 2)
            UpdateTextBoxes();

            // Teleport to Finish destination and reset velocity to 0
            transform.position = finishTeleportLocation;
            ResetVelocity();
        }
    }

    // Function to reset the velocity to 0
    void ResetVelocity()
    {
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;  // Reset the velocity of the Rigidbody2D
        }
    }

    // Function to update the text in the text boxes
    void UpdateTextBoxes()
    {
        // Update the text on text boxes with the new values
        textBox1.text = value1.ToString();
        textBox2.text = value2.ToString();
    }
}
