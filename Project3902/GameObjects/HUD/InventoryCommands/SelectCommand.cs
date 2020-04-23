namespace Project3902
{
    class SelectCommand : ICommand
    {
        public void Execute()
        {
            PauseScreen.Instance.SelectItem();
        }
    }
}
