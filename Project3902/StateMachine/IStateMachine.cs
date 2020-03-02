using System;

namespace Project3902
{
    interface IStateMachine<EnumType> : IUpdatable where EnumType : Enum
    {
        EnumType CurrentStateEnum { get; }

        void SwitchState(EnumType state);
    }
}
