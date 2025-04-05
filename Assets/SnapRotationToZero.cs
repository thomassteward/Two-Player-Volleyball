using UnityEngine;

public class SnapRotationToZero : MonoBehaviour
{
    void Start()
    {
        // Snap rotation to 0 degrees on the Z-axis at the start
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }
}
