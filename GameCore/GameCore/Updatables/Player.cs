using System;

namespace GameCore
{
    public class Player : IUpdate
    {
        private readonly IGetUserInputs Inputs;

        public Player(IGetUserInputs inputs)
        {
            Inputs = inputs;
        }

        public void Update(float deltaTime)
        {
            if (Inputs.UpPressed())
            {
            }
        }
    }
}
