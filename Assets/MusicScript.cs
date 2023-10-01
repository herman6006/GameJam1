using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
    private AudioSource audiosource;

    private void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }
    public void StartMusic()
    {
        audiosource.Play();
    }
}
