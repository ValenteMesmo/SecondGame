using Common.PubSubEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.GameComponents.PlayerComponents
{
    public class PlayerWarpTopOnBotLimit
    {
        public PlayerWarpTopOnBotLimit(Sandbox sandbox)
        {
            sandbox.PlayerUpdate.Subscribe(OnPlayerUpdate);
        }

        private void OnPlayerUpdate(Player obj)
        {
            if (obj.Body.Y < - 60)
            {
                obj.Body.Y = 59;
            }
        }
    }
}
