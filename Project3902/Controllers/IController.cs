namespace Project3902
{
    interface IController<T>
    {
        void Update();

        void RegisterCommand(T input, ICommand command);

        void RegisterCommand(T input, ICommand command, InputState state);
    }
}
