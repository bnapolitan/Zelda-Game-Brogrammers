namespace Project3902
{
    class LeftCommand : ICommand
    {
        public void Execute()
        {
            PauseScreen.Instance.MoveSelectorLeft();
        }
    }
}
