using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelDetonate : MonoBehaviour
{
    [SerializeField] private ParticleSystem posionGas;
    private SpriteRenderer sprd;
    private void Start()
    {
        sprd = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Spike"))
        {
            posionGas.Play();
            sprd.enabled = false;
            Invoke("Gameover",5f);
        }
    }

    private void Gameover()
    {
        print("ded");
    }
}
