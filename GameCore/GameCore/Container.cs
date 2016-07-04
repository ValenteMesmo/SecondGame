using GameCore.Updatables;
using System;
using System.Collections.Generic;

namespace GameCore
{
    public static class Factory
    {
        private static UserInputs inputs = new UserInputs();

        public static ISetUserInputs GetInputSetter()
        {
            return inputs;
        }

        public static IPlayer CreatePlayer()
        {
            var collider = new Collider();

            return new Player(
                new UpdateAggregator(
                    new MovesColliderLeftWhenPlayerInputsLeft(
                        new MovementController(collider, 0.01f),
                        inputs)
                    ), collider);
        }
    }
}
