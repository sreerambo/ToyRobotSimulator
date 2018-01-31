using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobotSimulator.Common.Contracts
{
    public interface IBidirectionalMapper<T1, T2>
    {
        T1 Map(T2 toMap);
        T2 Map(T1 toMap);
    }
}
