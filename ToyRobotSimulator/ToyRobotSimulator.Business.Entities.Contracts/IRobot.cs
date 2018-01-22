using System;

namespace ToyRobotSimulator.Business.Entities.Contracts
{
    public interface IRobot
    {
        //moves the robot one unit forward in the direction it is currently facing
        bool Move();

        //turn the robot in place to the left of where it is facing
        bool Left();

        //turn the robot in place to the right of where it is facing
        bool Right();
    }
}
