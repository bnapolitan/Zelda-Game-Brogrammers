namespace Project3902
{
    class RightCommand : ICommand
    {
        public void Execute()
        {
            PauseScreen.Instance.MoveSelectorRight();
        }
    }
}
