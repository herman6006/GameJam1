using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class ColorChanger : MonoBehaviour
{
    private Image images;
    private void Start()
    {
        images = GetComponent<Image>();
        images.color = Color.red;
    }
    private void ChangeColors(int randomValue)
    {
        if (randomValue == 0)
        {
            images.color = Color.red;
        }
        else if (randomValue == 1)
        {
            images.color = Color.green;
        }
        else if (randomValue == 2)
        {
            images.color = Color.blue;
        }
        else if (randomValue == 3)
        {
            images.color = Color.yellow;
        }
    }
}
