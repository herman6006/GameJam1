using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{

    private AudioSource audiosource;
    [SerializeField] private AudioClip ambiance, gameJam;
    private void Start()
    {
        audiosource = GetComponent<AudioSource>();
        audiosource.clip = ambiance;
        audiosource.loop = true;
        audiosource.Play();
    }
    public void StartMusic()
    {
        audiosource.clip = gameJam;
        audiosource.loop = false;
        audiosource.Play();
    }
    public void StopMusic()
    {
        audiosource.Stop();
    }
}
