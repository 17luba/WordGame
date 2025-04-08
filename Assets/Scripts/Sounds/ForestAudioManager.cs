using UnityEngine;

public class ForestAudioManager : MonoBehaviour
{
    public AudioSource backgroundMusic;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        backgroundMusic.Play();
    }
}
