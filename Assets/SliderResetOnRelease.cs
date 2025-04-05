using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SliderResetOnRelease : MonoBehaviour, IPointerUpHandler
{
    private Scrollbar scrollbar;

    void Start()
    {
        scrollbar = GetComponent<Scrollbar>();
        scrollbar.value = 0.5f; // Reset to the middle (0.5f is the center)
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (scrollbar != null)
        {
            scrollbar.value = 0.5f; // Reset to the middle (0.5f is the center)
        }
    }
}
