using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wire : MonoBehaviour
{
    private SpriteRenderer sprd;
    [SerializeField] private Sprite wireOn;
    private Sprite wireOff;
    void Start()
    {
        sprd = GetComponent<SpriteRenderer>();
        wireOff = sprd.sprite;
    }

    private void TurnOn()
    {
        sprd.sprite = wireOn;
    }

    private void TurnOff()
    {
        sprd.sprite = wireOff;
    }
}
