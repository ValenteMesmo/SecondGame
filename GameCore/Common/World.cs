using System;
using System.Collections.Generic;

namespace Common
{
    public class World
    {
        private IList<Action<int>> updateActionsList =
            new List<Action<int>>();

        private IList<Collider> colliders =
            new List<Collider>();

        public void AddPlayer(Action<Player> onPlayerUpdated)
        {
            var player = new Player();
            player.Body.Width = 1;
            player.Body.Height = 1;
            player.Body.OnRightCollision = other =>
            {
                other.X = (player.Body.X + player.Body.Width);
            };

            colliders.Add(player.Body);

            updateActionsList.Add(millisecondsSinceLastUpdate =>
            {
                player.Update(millisecondsSinceLastUpdate);
                onPlayerUpdated(player);
            });
        }

        public void AddMonster(Action<Collider> onMonsterUpdated)
        {
            var collider = new Collider();
            collider.X = 3;
            collider.Width = 1;
            collider.Height = 1;
            colliders.Add(collider);

            updateActionsList.Add(millisecondsSinceLastUpdate =>
            {
                onMonsterUpdated(collider);
            });
        }

        private DateTime updatedAt = DateTime.Now;
        public void Update()
        {
            var millisecondsSinceLastUpdate =
                (DateTime.Now - updatedAt).Milliseconds;

            foreach (var updateAction in updateActionsList)
            {
                updateAction(millisecondsSinceLastUpdate);
            }

            colliders.HandleCollisions();

            updatedAt = DateTime.Now;
        }
    }
}