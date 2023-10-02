using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public Transform cameraTransform;
    public float shakeDuration = 2f;
    public float shakeMagnitude = 0.1f;

    private Vector3 originalPosition;
    private float currentDuration = 0f;

    void Start()
    {
        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
        }
    }

    public void Shake()
    {
        originalPosition = cameraTransform.localPosition;
        currentDuration = shakeDuration;
        Invoke("Fix", shakeDuration + 0.01f);
    }

    void Update()
    {
        if (currentDuration > 0)
        {
            cameraTransform.localPosition = originalPosition + Random.insideUnitSphere * shakeMagnitude;
            currentDuration -= Time.deltaTime;
        }
        else
        {
            currentDuration = 0f;
            cameraTransform.localPosition = originalPosition;
        }
    }

    private void Fix()
    {
        var tempColor = cameraTransform.GetComponent<SpriteRenderer>().color;
        tempColor.a = 0;
        cameraTransform.GetComponent<SpriteRenderer>().color = tempColor;
    }
}
