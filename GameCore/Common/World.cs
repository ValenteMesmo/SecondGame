using System;
using System.Collections.Generic;

namespace Common
{
    public class World
    {
        private IList<Action<int>> updatesBeforeCollision =
            new List<Action<int>>();

        private IList<Action> updateAfterCollision =
            new List<Action>();

        private IList<Collider> colliders =
            new List<Collider>();

        public void AddPlayer(
            float x,
            float y,
            Action<Player> onPlayerUpdated)
        {
            var player = new Player();
            player.Body.X = x;
            player.Body.Y = y;
            player.Body.Width = 1;
            player.Body.Height = 1;

            player.Body.OnRightCollision = other =>
            {
                player.Body.X = 
                    other.X - player.Body.Width;
            };
            player.Body.OnLeftCollision = other =>
            {
                player.Body.X = 
                    other.X + other.Width;
            };

            colliders.Add(player.Body);

            updatesBeforeCollision.Add(millisecondsSinceLastUpdate =>
                player.Update(millisecondsSinceLastUpdate)
            );

            updateAfterCollision.Add(() =>
                onPlayerUpdated(player)
            );
        }

        public void AddMonster(
            float x,
            float y,
            Action<Collider> onMonsterUpdated)
        {
            var collider = new Collider();
            collider.X = x;
            collider.Y = y;
            collider.Width = 1;
            collider.Height = 1;

            collider.OnRightCollision = other =>
            {
                collider.X = other.X - collider.Width;
            };

            collider.OnLeftCollision = other =>
            {
                collider.X = other.X + other.Width;
            };

            colliders.Add(collider);

            updatesBeforeCollision.Add(millisecondsSinceLastUpdate =>
            {
                onMonsterUpdated(collider);
            });
        }

        private DateTime updatedAt = DateTime.Now;
        public void Update()
        {
            var millisecondsSinceLastUpdate =
                (DateTime.Now - updatedAt).Milliseconds;

            foreach (var updateAction in updatesBeforeCollision)
            {
                updateAction(millisecondsSinceLastUpdate);
            }

            colliders.HandleCollisions();

            foreach (var lateUpdate in updateAfterCollision)
            {
                lateUpdate();
            }

            updatedAt = DateTime.Now;
        }
    }
}