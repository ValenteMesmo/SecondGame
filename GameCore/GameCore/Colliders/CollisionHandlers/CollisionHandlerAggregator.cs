﻿using GameCore.Commons;
using System.Collections.Generic;

namespace GameCore.CollisionHandlers
{
    public class CollisionHandlerAggregator : IHandleCollision
    {
        private readonly IEnumerable<IHandleCollision> Handlers;

        public CollisionHandlerAggregator(params IHandleCollision[] handlers)
        {
            Handlers = handlers;
        }

        public void Handle(Collider first, Collider second)
        {
            foreach (var handler in Handlers)
            {
                handler.Handle(first, second);
            }
        }
    }
}