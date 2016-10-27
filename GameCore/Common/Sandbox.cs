using System;
using System.Collections.Generic;

namespace Common
{
    public class Sandbox
    {
        private Dictionary<string, List<Action<object>>> Callbacks =
            new Dictionary<string, List<Action<object>>>();

        public void Pub<T>(string eventName, T args, string channel = "")
        {
            eventName += channel;
            if (Callbacks.ContainsKey(eventName))
                foreach (var item in Callbacks[eventName])
                {
                    item(args);
                }
        }

        public void Pub(string eventName, string channel = "")
        {
            eventName += channel;
            if (Callbacks.ContainsKey(eventName))
                foreach (var item in Callbacks[eventName])
                {
                    item(null);
                }
        }

        public void Sub<T>(string eventName, Action<T> callback, string channel = "")
        {
            eventName += channel;
            if (Callbacks.ContainsKey(eventName) == false)
                Callbacks.Add(eventName, new List<Action<object>>());

            Callbacks[eventName].Add(new Action<object>(o => callback((T)o)));
        }

        public void Sub(string eventName, Action callback, string channel = "")
        {
            eventName += channel;
            if (Callbacks.ContainsKey(eventName) == false)
                Callbacks.Add(eventName, new List<Action<object>>());

            Callbacks[eventName].Add(new Action<object>(o => callback()));
        }
    }

    public class EventNames
    {
        public const string WORLD_UPDATE = "world_update";
        public const string COLLISIONS_DETECTION_REQUESTED = "collisions_detection_requested";
        public const string WORLD_ADD_PLAYER = "world_add_player";
        public const string WORLD_ADD_MONSTER = "world_add_monster";
        public const string COLLIDER_CREATED = "collider_created";
        public const string PLAYER_CREATION_REQUESTED = "player_creation_requested";
        public const string PLAYER_UPDATED = "player_updated";
        public const string MONSTER_CREATION_REQUESTED = "monster_creation_requested";
        public const string COLLISION_FROM_ABOVE = "collision_from_above";
        public const string COLLISION_FROM_BELOW = "collision_from_below";
        public const string COLLISION_FROM_THE_LEFT = "collision_from_the_left";
        public const string COLLISION_FROM_THE_RIGHT = "collision_from_the_right";
        public const string COLLISION_FROM_ANY_DIRECTION = "collision_from_any_direction";
    }
}
