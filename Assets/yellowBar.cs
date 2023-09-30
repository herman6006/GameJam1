using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class yellowBar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        gameObject.SetActive(true);
    }
    private void FixedUpdate()
    {
        transform.Translate(new Vector3(-1, 0));
    }
}
