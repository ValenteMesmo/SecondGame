using System;
using System.Collections.Generic;

namespace GameCore.Updatables
{
    public class UpdateAggregator : IUpdate
    {
        private readonly IEnumerable<IUpdate> Updates;

        public UpdateAggregator(IEnumerable<IUpdate> updates)
        {
            Updates = updates;
        }

        public void Update(float deltaTime)
        {
            foreach (var item in Updates)
            {
                item.Update(deltaTime);
            }
        }
    }
}
