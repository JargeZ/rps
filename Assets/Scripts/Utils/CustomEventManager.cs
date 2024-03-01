using System;
using System.Collections.Generic;
using UnityEngine;

namespace EventManager {
public enum CustomEventType
{
    ScreenSizeChanged,
    // Add other event types here
}

public class CustomEventManager : MonoBehaviour
{
    private static Dictionary<CustomEventType, Action> eventDictionary = new Dictionary<CustomEventType, Action>();

    private float _lastScreenWidth = 0;

    public static void StartListening(CustomEventType eventType, Action listener)
    {
        if (eventDictionary.ContainsKey(eventType))
        {
            eventDictionary[eventType] += listener;
        }
        else
        {
            eventDictionary[eventType] = listener;
        }
    }

    public static void StopListening(CustomEventType eventType, Action listener)
    {
        if (eventDictionary.ContainsKey(eventType))
        {
            eventDictionary[eventType] -= listener;
        }
    }

    public static void TriggerEvent(CustomEventType eventType)
    {
        Action thisEvent;
        if (eventDictionary.TryGetValue(eventType, out thisEvent))
        {
            thisEvent.Invoke();
        }
    }

    public void OnEnable()
    {
        _lastScreenWidth = Screen.width;
    }

    public void Update()
    {
        if (Screen.width != _lastScreenWidth)
        {
            _lastScreenWidth = Screen.width;
            TriggerEvent(CustomEventType.ScreenSizeChanged);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TriggerEvent(CustomEventType.ScreenSizeChanged);
        }
    }
}
}