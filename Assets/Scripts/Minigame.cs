using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame : MonoBehaviour
{
    private SpriteRenderer sprd;
    [SerializeField] private Sprite MachineMinigame;
    private Sprite MachineMinigameOff;
    void Start()
    {
        sprd = GetComponent<SpriteRenderer>();
        MachineMinigameOff = sprd.sprite;
    }

    private void TurnOn()
    {
        sprd.sprite = MachineMinigame;
    }

    private void TurnOff()
    {
        sprd.sprite = MachineMinigameOff;
    }
}
