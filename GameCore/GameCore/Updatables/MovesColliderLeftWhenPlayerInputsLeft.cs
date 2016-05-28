using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCore.Updatables
{
    public class MovesColliderLeftWhenPlayerInputsLeft : IUpdate
    {
        private readonly IGetUserInputs Inputs;
        private readonly MovementController Controller;

        public MovesColliderLeftWhenPlayerInputsLeft(
            MovementController controller,
            IGetUserInputs inputs)
        {
            Inputs = inputs;
            Controller = controller;
        }

        public void Update(float deltaTime)
        {
            if (Inputs.LeftIsPressed())
                Controller.SpeedUpToTheLeft();
        }
    }

    public class MovementController
    {
        private readonly Collider Collider;
        private readonly float Acceleration;

        private const float MAX_SPEED = 10f;
        private const float MIN_SPEED = -10f;
        private float speed = 0;

        public MovementController(
            Collider collider,
            float acceleration)
        {
            Collider = collider;
            if (acceleration <= 0)
                throw new ArgumentException(
                    "acceleration", 
                    "Sorry! Acceleration must be greater than zero!");
            Acceleration = acceleration;
        }

        public void SlowDown()
        {
            if (speed > 0)
            {
                speed -= Acceleration;
            }
            else if (speed < 0)
            {
                speed += Acceleration;
            }

            Collider.X += speed;
        }

        public void SpeedUpToTheLeft()
        {
            speed -= Acceleration;

            if (speed < MIN_SPEED)
                speed = MIN_SPEED;

            Collider.X += speed;
        }

        public void SpeedUpToTheRight()
        {
            speed += Acceleration;

            if (speed > MAX_SPEED)
                speed = MAX_SPEED;

            Collider.X += speed;
        }
    }
}