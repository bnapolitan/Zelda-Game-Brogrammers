namespace Project3902
{
    class DownCommand : ICommand
    {
        public void Execute()
        {
            PauseScreen.Instance.MoveSelectorDown();
        }
    }
}
