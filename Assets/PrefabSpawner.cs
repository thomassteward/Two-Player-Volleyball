using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    public GameObject prefabToSpawn;  // The prefab to instantiate
    public AudioClip soundClip;       // The sound to play
    private AudioSource audioSource;  // The AudioSource to play the sound

    void Start()
    {
        // Make sure we have an AudioSource on this object to play sounds
        audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    // This function can be called by a button to spawn the prefab and play the sound
    public void SpawnPrefabAndPlaySound()
    {
        // Instantiate the prefab at a random position (for example, here)
        Vector3 spawnPosition = new Vector3(0, 0, 0); // You can change this to any position you want
        if (prefabToSpawn != null)
        {
            // Instantiate the prefab at the specified position
            Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
        }

        if (soundClip != null)
        {
            // Play the sound
            audioSource.PlayOneShot(soundClip);
        }
    }
}
