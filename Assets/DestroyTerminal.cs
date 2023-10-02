using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTerminal : MonoBehaviour
{
    [SerializeField] private ParticleSystem explosion;
    [SerializeField] AudioClip explodeTerminalSFX;
    private AudioSource audioSource;
    private SpriteRenderer sprd;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        sprd = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Spike"))
        {
            explosion.Play();
            audioSource.PlayOneShot(explodeTerminalSFX, 0.6f);
            sprd.enabled = false;
        }
    }
}
