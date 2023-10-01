using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] private AudioClip electricity;
    public bool isActive = false;

    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            BroadcastMessage("TurnOn");
            isActive = true;
            audioSource.PlayOneShot(electricity, 0.3f);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            BroadcastMessage("TurnOff");
            isActive = false;
        }
    }
}
