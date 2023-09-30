using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Task1Controller : MonoBehaviour
{
    [SerializeField] private GameObject pressurePlate, task1trigger;
    private bool canStart;
    private bool inArea;
    void Update()
    {
        canStart = pressurePlate.GetComponent<PressurePlate>().isActive;
        inArea = task1trigger.GetComponent<Task1Trigger>().isAtTerminal;
    }

}
