using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class slushynioiobz : MonoBehaviour
{
    private Scrollbar scrollbar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scrollbar = GetComponent<Scrollbar>();
        scrollbar.value = 0.5f; // Reset to the middle (0.5f is the center)
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
