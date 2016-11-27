﻿using UnityEngine;

public static class EventExtensions
{
    public static void LogEventCalls(this Common.PubSubEngine.Event e, string message)
    {
        e.Subscribe(() => Debug.Log(message));
    }

    public static void LogEventCalls<T>(this Common.PubSubEngine.Event<T> e, string message)
    {
        e.Subscribe(f => Debug.Log(message));
    }
}
