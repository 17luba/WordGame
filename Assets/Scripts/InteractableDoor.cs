using UnityEngine;

public class InteractableDoor : MonoBehaviour
{
    [Header("Animation")]
    [SerializeField] private Animator animator;
    [SerializeField] private bool isOpen;

    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip doorOpenSound;
    [SerializeField] private AudioClip doorCloseSound;

    public bool IsOpen => isOpen;

    private void Start()
    {
        animator.SetBool("isOpen", isOpen);
    }

    public void Use()
    {
        if (isOpen)
            Close();
        else
            Open();
    }

    public void Open()
    {
        isOpen = true;
        animator.SetBool("isOpen", true);
        PlaySound(doorOpenSound, 1.3f); // pitch plus élevé = son plus rapide
    }

    public void Close()
    {
        isOpen = false;
        animator.SetBool("isOpen", false);
        PlaySound(doorCloseSound, 1.2f); // tu peux ajuster selon le besoin
    }

    private void PlaySound(AudioClip clip, float pitch = 1.2f)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.Stop();
            audioSource.pitch = pitch;
            audioSource.clip = clip;
            audioSource.Play();
        }
    }

}
