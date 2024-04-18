using System;
using UnityEngine;

public class Door : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            EventManager.onFinishLevel.Invoke();
        }
    }
}