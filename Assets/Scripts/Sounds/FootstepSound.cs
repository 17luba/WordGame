using UnityEngine;

public class FootstepSound : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip footstepClip;
    [SerializeField] private float footstepInterval = 0.5f;

    private float stepTimer;

    private CharacterController controller;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
        stepTimer = footstepInterval;
    }

    // Update is called once per frame
    void Update()
    {
        // Vérifie si le personnage est en mouvement
        if (controller.isGrounded && controller.velocity.magnitude > 0.1f)
        {
            stepTimer -= Time.deltaTime;

            // Joue le son de pas si le timer est écoulé
            if (stepTimer <= 0f)
            {
                PlayFootstepSound();
                stepTimer = footstepInterval;
            }
        }
        else
        {
            stepTimer = 0f; // Reset le timer si le personnage est immobile
        }
    }

    private void PlayFootstepSound()
    {
        if (audioSource != null && footstepClip != null)
        {
            audioSource.PlayOneShot(footstepClip);
        }
    }
}
