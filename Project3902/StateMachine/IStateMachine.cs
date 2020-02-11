using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902
{
    interface IStateMachine<EnumType> : IUpdatable where EnumType : Enum
    {
        EnumType CurrentStateEnum { get; }

        void SwitchState(EnumType state);
    }
}
