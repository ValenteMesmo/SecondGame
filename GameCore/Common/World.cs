using System;
using System.Collections.Generic;

namespace Common
{
    public class World
    {
        public readonly Sandbox Sandbox = new Sandbox();

        public void AddPlayer(float x, float y)
        {
            new Player(Sandbox, x, y);
            //Sandbox.Pub(EventNames.PLAYER_CREATION_REQUESTED, new Position(x, y));
        }

        public void AddMonster(float x, float y)
        {
            Sandbox.Pub(EventNames.MONSTER_CREATION_REQUESTED, new Position(x, y));
        }

        public void Update()
        {
            Sandbox.Pub(EventNames.WORLD_UPDATE);
            Sandbox.Pub(EventNames.COLLISIONS_DETECTION_REQUESTED);
        }
    }
}