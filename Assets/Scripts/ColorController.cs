using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorController : MonoBehaviour
{
    [SerializeField] private GameObject RGBBAR;
    private Color current = Color.red;

    public void SetColorRed()
    {
        print(current);
        RGBBAR.GetComponent<RGBBAR>().currentColor = current;
    }
    public void ChangeColor()
    {
        var randomValue = (Random.Range(0, 4));
        if (randomValue == 0)
        {
            current = Color.red;
        }
        else if (randomValue == 1)
        {
            current = Color.green;
        }
        else if (randomValue == 2)
        {
            current = Color.blue;
        }
        else if (randomValue == 3)
        {
            current = Color.yellow;
        }
        BroadcastMessage("ChangeColors", randomValue);
        RGBBAR.GetComponent<RGBBAR>().currentColor = current;
    }
}
