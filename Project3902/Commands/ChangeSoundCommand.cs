using Project3902.ObjectManagement;

namespace Project3902
{
    class ChangeSoundCommand : ICommand
    {
        public ChangeSoundCommand()
        {
        }
        public void Execute()
        {
            int currentState = SoundHandler.Instance.SoundType;
            if (currentState == 0)
            {
                SoundHandler.Instance.UseCustomSounds();
            }
            else
            {
                SoundHandler.Instance.UseDefaultSounds();
            }
            
        }
    }
}
