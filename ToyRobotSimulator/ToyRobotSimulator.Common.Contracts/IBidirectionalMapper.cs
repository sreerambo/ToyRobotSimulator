using System;

namespace ToyRobotSimulator.Common.Contracts
{
    public interface IBidirectionalMapper<T1, T2>
    {
        T1 Map(T2 toMap);
        T2 Map(T1 toMap);
    }
}
