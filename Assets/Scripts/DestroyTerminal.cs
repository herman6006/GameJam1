using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTerminal : MonoBehaviour
{
    [SerializeField] private GameObject miniMachineOff;
    [SerializeField] private ParticleSystem explosion;
    [SerializeField] AudioClip explodeTerminalSFX;
    private AudioSource audioSource;
    private SpriteRenderer sprd, sprd2;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        sprd = GetComponent<SpriteRenderer>();
        sprd2 = miniMachineOff.GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Spike"))
        {
            explosion.Play();
            audioSource.PlayOneShot(explodeTerminalSFX, 0.6f);
            sprd.enabled = false;
            sprd2.enabled = false;
        }
    }
}
