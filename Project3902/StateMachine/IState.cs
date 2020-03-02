namespace Project3902
{
    interface IState : IUpdatable
    {
        void Enter();

        void Exit();
    }
}
