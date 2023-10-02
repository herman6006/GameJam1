using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class RGBBAR : MonoBehaviour
{
    private RectTransform rect;
    public bool isTouching = false;
    private float multiplier;
    private UnityEngine.UI.Image image;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        image = GetComponent<UnityEngine.UI.Image>();
        gameObject.SetActive(true);
        multiplier = 5 + (Random.value * 5f);

        
        image.color = new Color(Random.value, Random.value, Random.value);
    }

    private void FixedUpdate()
    {
        rect.localPosition += Vector3.left * multiplier;
    }

    private void ButtonPressed()
    {
        if (isTouching)
        {
            SendMessageUpwards("AddPoint");
            Destroy(gameObject);
        }
    }

    private void DestroyAllRemaining()
    {
        Destroy(gameObject);
    }
}
