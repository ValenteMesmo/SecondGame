using Common.PubSubEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.GameComponents.PlayerComponents
{
    public class PlayerWarpRightOnLeftLimit
    {
        public PlayerWarpRightOnLeftLimit(Sandbox sandbox)
        {
            sandbox.PlayerUpdate.Subscribe(OnPlayerUpdate);
        }

        private void OnPlayerUpdate(Player obj)
        {            
            if (obj.Body.X > 66)
            {
                obj.Body.X = -69;
            }
        }
    }
}
