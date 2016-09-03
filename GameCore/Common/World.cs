using System;
using System.Collections.Generic;

namespace Common
{
    public class World
    {
        private IList<Action<int>> updateActionsList =
            new List<Action<int>>();

        public void AddPlayer(Action<Player> playerUpdated)
        {
            var player = new Player();
            updateActionsList.Add(millisecondsSinceLastUpdate =>
            {
                player.Update(millisecondsSinceLastUpdate);
                playerUpdated(player);
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

            updatedAt = DateTime.Now;
        }

    }
}