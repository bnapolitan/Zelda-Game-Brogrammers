namespace Project3902
{
    class UpCommand : ICommand
    {
        public void Execute()
        {
            PauseScreen.Instance.MoveSelectorUp();
        }
    }
}
