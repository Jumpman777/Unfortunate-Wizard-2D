using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class BaseSummonObject : MonoBehaviour
{
    [SerializeField, Tooltip("The object can have multiple colliders")] private Collider2D[] colliders;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidBody;
    private Color _normalColor = new Color(1f, 1f, 1f, 1f);

    private void SetColliderTriggerStatus(bool isTrigger)
    {
        foreach (var collider in colliders)
        {
            collider.isTrigger = isTrigger;
        }
    }

    public void SetColor(Color color)
    {
        _spriteRenderer.color = color;
    }
    
    public void SetToIndicatorMode()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidBody = GetComponent<Rigidbody2D>();
        SetColliderTriggerStatus(true);
        _rigidBody.simulated = false;
        _rigidBody.velocity = Vector2.zero;
        _rigidBody.angularVelocity = 0f;
    }

    // only runs if colliders are in trigger state
    private void OnTriggerEnter2D(Collider2D other)
    {
        EventManager.onIndicatorObjectChangeTriggerCollision.Invoke(true);
        Debug.Log("on Indicator Object Change Trigger Collision invoked with true");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        EventManager.onIndicatorObjectChangeTriggerCollision.Invoke(false);
        Debug.Log("on Indicator Object Change Trigger Collision invoked with false");
    }
    
    public void SetToNormalMode()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidBody = GetComponent<Rigidbody2D>();
        SetColliderTriggerStatus(false);
        _rigidBody.simulated = true;
        SetColor(_normalColor);
    }
}