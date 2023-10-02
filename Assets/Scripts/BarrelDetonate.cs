using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BarrelDetonate : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen, player, playArea, musicPlayer;
    [SerializeField] private ParticleSystem posionGas;
    [SerializeField] private AudioClip smokeSFX;
    [SerializeField] private TMP_Text deathText;
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
            posionGas.Play();
            audioSource.PlayOneShot(smokeSFX, 0.6f);
            sprd.enabled = false;
            Invoke("Gameover",5f);
            Invoke("BecomeGreen", 1.5f);
        }
    }

    private void Gameover()
    {
        deathText.text = "Died to toxic gas";
        gameOverScreen.SetActive(true);
        playArea.GetComponent<ShrinkLevel>().StopShrink();
        musicPlayer.GetComponent<MusicScript>().StopMusic();
        
    }

    private void BecomeGreen()
    {
        player.GetComponent<SpriteRenderer>().color = Color.green;
    }
}
