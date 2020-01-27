using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Sprint0
{
    interface IController<T>
    {
        void Update();
        void RegisterCommand(T input, ICommand command);
    }
}
