using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class yellowBar : MonoBehaviour
{
    private RectTransform rect;
    public bool isTouching = false;
    private float multiplier;
    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        gameObject.SetActive(true);
        multiplier = 5+ (Random.value * 5f);
    }
    private void FixedUpdate()
    {
        rect.localPosition += Vector3.left*multiplier;
    }
    private void ButtonPressed()
    {
        if (isTouching)
        {
            SendMessageUpwards("AddPoint");
            Destroy(gameObject);
        }
    }

    private void DestroyAllRemaining() { Destroy(gameObject); }
}
