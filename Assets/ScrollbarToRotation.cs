using UnityEngine;
using UnityEngine.UI;

public class ScrollbarToRotation : MonoBehaviour
{
    public Scrollbar rotationScrollbar;  // The scrollbar controlling the rotation
    public GameObject targetObject;      // The object to rotate

    void Update()
    {
        if (rotationScrollbar != null && targetObject != null)
        {
            // Map the scrollbar value (0 to 1) to a rotation range of -180 to 180 degrees
            float rotationValue = (rotationScrollbar.value - 0.5f) * 360f; // Map 0.5 to 0 and 1 to 180

            // Apply the Z rotation to the object
            targetObject.transform.rotation = Quaternion.Euler(0f, 0f, rotationValue);
        }
    }
}
