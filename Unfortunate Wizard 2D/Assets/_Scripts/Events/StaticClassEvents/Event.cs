using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Event
{
    private event Action _event = delegate {  };

    public void Invoke()
    {
        _event?.Invoke();
    }
    
    /// <summary>
    /// Subscribe event. Usually done in OnEnable()
    /// </summary>
    /// <param name="listener">The method name to be invoked in response to the event. </param>
    public void Subscribe(Action listener)
    {
        _event -= listener; //Remove subscriber in case already subscribed. If not subscribed, does nothing.
                            //Not safe for multi-threading
        _event += listener;
    }
    public void Unsubscribe(Action listener)
    {
        _event -= listener;
    }
}

/// <summary>
/// Event with a parameter
/// </summary>
/// <typeparam name="T"></typeparam>
public class Event<T>
{
    private event Action<T> _event = delegate{  };

    public void Invoke(T parameter)
    {
        _event?.Invoke(parameter);
    }
    
    public void Subscribe(Action<T> listener)
    {
        _event -= listener; //Remove subscriber in case already subscribed. If not subscribed, does nothing.
        //Not safe for multi-threading
        _event += listener;
    }
    public void Unsubscribe(Action<T> listener)
    {
        _event -= listener;
    }
}