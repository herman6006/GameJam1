using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task1Trigger : MonoBehaviour
{
    private SpriteRenderer sprd;
    public bool isAtTerminal = false;
    private void Start()
    {
        sprd = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isAtTerminal = true;
            sprd.enabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            sprd.enabled = false;
            isAtTerminal = false;
        }
    }
}
