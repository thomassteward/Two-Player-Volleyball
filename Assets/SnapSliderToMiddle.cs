using UnityEngine;
using UnityEngine.UI;

public class SnapSliderToMiddle : MonoBehaviour
{
    public Slider rotationSlider; // The slider to snap to the middle

    void Start()
    {
        // Set the slider's value to 0.5 (middle) when the game starts
        if (rotationSlider != null)
        {
            rotationSlider.value = 0.5f;
        }
    }
}
