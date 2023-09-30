using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public bool isActive = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            BroadcastMessage("TurnOn");
            isActive = true;
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
