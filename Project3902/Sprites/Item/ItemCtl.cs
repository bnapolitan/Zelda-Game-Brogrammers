using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902
{
    class ItemCtl 
    {
        public static ItemCtl Instance { get; } = new ItemCtl();
        public ItemReg ItemRegister( Sprint2 game)
        {
            var ItController = new ItemReg();

            ItController.RegisterCommand(Keys.I, new CycNxtItm(game));
            //ItController.RegisterCommand(Keys.U, new LinkMoveDownCommand(link));

            return ItController;
        }
    }
}
