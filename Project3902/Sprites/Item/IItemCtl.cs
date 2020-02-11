using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902
{
    interface IItemCtl
    {
        void Update();
        void RegisterCommand(Keys key, ICommand command);
    }
}
