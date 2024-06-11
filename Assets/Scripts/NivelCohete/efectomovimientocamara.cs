using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class efectomovimientocamara : MonoBehaviour
{
    public float shakeDuration = 20f;
    public float shakeAmount = 0.1f;
    public float decreaseFactor = 1.0f;

    private Vector3 originalPosition;

    void Start()
    {
        originalPosition = transform.position;
    }

    void Update()
    {
        if (shakeDuration > 0)
        {
            transform.position = originalPosition + Random.insideUnitSphere * shakeAmount;
            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shakeDuration = 0f;
            transform.position = originalPosition;
        }
    }
}
