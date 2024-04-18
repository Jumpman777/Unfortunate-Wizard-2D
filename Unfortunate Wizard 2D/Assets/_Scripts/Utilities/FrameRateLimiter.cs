using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameRateLimiter : MonoBehaviour
{
    [SerializeField] private int targetFrameRate = 60;
    private void Start()
    {
        Application.targetFrameRate = targetFrameRate;
        Destroy(gameObject);
    }
}
