using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip backgroundMusic;  // The music to be played
    private AudioSource audioSource;   // The AudioSource component

    void Awake()
    {
        // If there's already a MusicManager in the scene, destroy this one to avoid duplicates
        if (FindObjectsOfType<MusicManager>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            // Set this object to not be destroyed on scene load
            DontDestroyOnLoad(gameObject);
        }

        // Get or add an AudioSource component
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Set the music to loop and start playing
        if (backgroundMusic != null)
        {
            audioSource.clip = backgroundMusic;
            audioSource.loop = true;
            audioSource.Play();
        }
    }
}
