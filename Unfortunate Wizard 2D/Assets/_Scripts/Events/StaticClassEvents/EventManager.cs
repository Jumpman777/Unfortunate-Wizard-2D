using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Used for storing events in one place.
/// This event system is less resource intensive than a scriptable object event system that uses UnityEvents.
/// Con: not as good for team collaboration, because of potential conflicts from working in this class.
/// </summary>
public static class EventManager
{
    public static Event<CardInfo> onCardSelected { get; } = new Event<CardInfo>();
    public static Event onCardDeselected { get; } = new Event();
    
    public static Event onHandEmpty { get; } = new Event();
    public static Event<CardInfo[]> onDrawCards { get; } = new Event<CardInfo[]>();
    
    public static Event onIndicatorRotate { get; } = new Event();
    public static Event<CardInfo> onSpawnObject { get; } = new Event<CardInfo>();
    
    public static Event onFinishLevel { get; } = new Event();
    public static Event onKillPlayer { get; } = new Event();
    
    public static Event<bool> onIndicatorObjectChangeTriggerCollision { get; } = new Event<bool>(); // bool isTriggerColliding
    
}
