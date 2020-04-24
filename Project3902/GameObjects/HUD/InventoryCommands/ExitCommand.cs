namespace Project3902
{
    class ExitCommand : ICommand
    {
        public void Execute()
        {
            PauseScreen.Instance.ExitGame();
        }
    }
}
