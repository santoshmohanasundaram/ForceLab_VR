using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance; // Singleton pattern
    private AudioSource currentAudio; // Track currently playing audio

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayAudio(AudioSource newAudio)
    {
        // Stop the currently playing audio if any
        if (currentAudio != null && currentAudio.isPlaying)
        {
            currentAudio.Stop();
        }

        // Stop any other audio sources in the scene (like the intro audio)
        AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();
        foreach (var audio in allAudioSources)
        {
            if (audio.isPlaying)
            {
                audio.Stop();
            }
        }

        // Play the new audio and set it as the current one
        currentAudio = newAudio;
        currentAudio.Play();
    }
}
