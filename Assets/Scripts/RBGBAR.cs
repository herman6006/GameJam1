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
    public Color currentColor = Color.red;
    private float multiplier;
    private UnityEngine.UI.Image image;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        image = GetComponent<UnityEngine.UI.Image>();
        gameObject.SetActive(true);
        multiplier = 8;
        var randomValue = (Random.Range(0, 4));
        if (randomValue == 0)
        {
            image.color = Color.red;
        }else if (randomValue == 1)
        {
            image.color = Color.green;
        }else if (randomValue == 2)
        {
            image.color = Color.blue;
        }else if (randomValue == 3)
        {
            image.color = Color.yellow;
        }
        
    }

    private void FixedUpdate()
    {
        rect.localPosition += Vector3.left * multiplier;
    }

    private void ButtonPressed()
    {
        print(image.color);
        print(currentColor);
        print(Color.red);
        if (isTouching && image.color == currentColor)
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
