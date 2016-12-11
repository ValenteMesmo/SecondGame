using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client.Components.Factories
{
    class OtherPlayersFactory
    {
        Sandbox Sandbox;
        public OtherPlayersFactory(Sandbox sandbox)
        {
            Sandbox = sandbox;
            Sandbox.ClinetEvents_OtherPlayerAdded.Subscribe(OnOtherPlayerAdded);
        }

        private void OnOtherPlayerAdded(string name)
        {
            var collider = new Collider(Sandbox, 0, 0, 3, 6, null, name);
            Sandbox.OtherPlayerPositionChanged.Subscribe(f =>
            {
                collider.X = f.X;
                collider.Y = f.Y;
            }, name);
        }
    }
}
